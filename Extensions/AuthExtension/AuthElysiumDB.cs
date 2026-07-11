using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class ElysiumAuthCredentials {
    public string jwt_token { get; set; }
    public string user_id { get; set; }
}

public class AuthElysiumDB : DBExtensionBase
{
    private const string TableName = "AuthSession";
    private const string ColumnToken = "jwt_token";
    private const string ColumnExpiry = "expiry_date";
    private const string ColumnUserId = "user_id";

    public bool IsAuthenticated { get; private set; }
    public DBMeta authTable;

    private IAuthElysiumReceiver[] _receivers => GetExtensions<IAuthElysiumReceiver>();

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("AuthElysiumDB initialized");
        
        elysium.CreateSQLiteDatabase("AuthElysiumDB.db");
        
        authTable = elysium["AuthElysiumDB.db"];

        CreateAuthTable(authTable);
        LoadAuthState(elysium);
    }

    private void CreateAuthTable(DBMeta authTable)
    {
        string createTableQuery = $@"
            CREATE TABLE IF NOT EXISTS {TableName} (
                id INTEGER PRIMARY KEY CHECK (id = 1),
                {ColumnToken} TEXT,
                {ColumnExpiry} INTEGER,
                {ColumnUserId} TEXT,
                updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
            );";

        authTable.Execute(createTableQuery);
    }

    public void Auth(string credentials)
    {
        var expiry = ExtractExpiryFromJwt(credentials);
        var sub = ExtractUserIdFromJwt(credentials);

        string insertOrUpdateQuery = $@"
            INSERT INTO {TableName} (id, {ColumnToken}, {ColumnExpiry}, {ColumnUserId})
            VALUES (1, @token, @expiry, @userid)
            ON CONFLICT(id) DO UPDATE SET 
                {ColumnToken} = @token,
                {ColumnExpiry} = @expiry,
                {ColumnUserId} = @userid,
                updated_at = CURRENT_TIMESTAMP;";

        authTable.Execute(
            insertOrUpdateQuery,
            parameters: new (string name, object value)[]
            {
                ("@token", credentials),
                ("@expiry", expiry),
                ("@userid", sub)
            }
        );

        IsAuthenticated = true;
        NotifyAuthTokenUpdated(credentials);
        FetchAuthUserData();
    }

    public void SignOut()
    {
        authTable.Execute($"DELETE FROM {TableName} WHERE id = 1;");
        IsAuthenticated = false;
        NotifyAuthTokenUpdated(null);
    }

    public ElysiumAuthCredentials GetCredentials()
    {
        var result = authTable.QueryFirst<ElysiumAuthCredentials>(
            $"SELECT * FROM {TableName} WHERE id = 1;",
            0
        );

        return result;
    }

    private void LoadAuthState(ElysiumDatabase elysium)
    {
        string token = GetCredentials()?.jwt_token;
        if (!string.IsNullOrEmpty(token))
        {
            IsAuthenticated = true;
            NotifyAuthTokenUpdated(token);
            FetchAuthUserData();
        }
    }

    private long ExtractExpiryFromJwt(string jwt)
        => GetJwtClaim<long>(jwt, "exp");

    private string ExtractUserIdFromJwt(string jwt)
        => GetJwtClaim<string>(jwt, "sub");

    private T GetJwtClaim<T>(string jwt, string claim)
    {
        try
        {
            var payload = jwt.Split('.')[1];

            payload = payload.PadRight(
                payload.Length + (4 - payload.Length % 4) % 4,
                '=');

            var json = JObject.Parse(
                System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(payload)));

            return json[claim]!.Value<T>();
        }
        catch
        {
            return default!;
        }
    }

    void NotifyAuthTokenUpdated(string newJwt)
    {
        foreach (var receiver in _receivers)
            receiver.OnAuthTokenUpdated(newJwt);
    }

    void FetchAuthUserData() {
        foreach (var receiver in _receivers)
            receiver.OnFetchAuthUserData(authTable);
    }

    protected override void OnDispose() {}
}