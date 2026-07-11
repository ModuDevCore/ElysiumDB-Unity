using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Reflection;
using Mono.Data.Sqlite;

using UnityEngine;

namespace ModuDevCore.ElysiumDB 
{
    public class DBMeta : IDisposable
    {
        public IDbConnection connection;
        public SqliteConnectionStringBuilder SqliteConnectionStringBuilder => new SqliteConnectionStringBuilder(connection.ConnectionString);

        private bool ShouldIgnoreLog(string log)
        {
            var ignores = ElysiumDatabase.Settings?.logIgnorePatterns;
            var showLogs = ElysiumDatabase.Settings?.showLogs??true;
            if (ignores == null || ignores.Count == 0 || !showLogs)
                return false;

            for (int i = 0; i < ignores.Count; i++)
            {
                var pattern = ignores[i];

                if (!string.IsNullOrEmpty(pattern) &&
                    (
                        log.Contains(pattern, StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    return true;
                }
            }

            return false;
        }
        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }

        public IDataReader Query(
            string cmd,
            int linesToRead = 0,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            string file = System.IO.Path.GetFileName(callerFile);

            if (!ShouldIgnoreLog(
                    $"LiteSQL request\n" +
                    $"QUERY: {cmd}\n" +
                    $"DB: {connection.ConnectionString}\n" +
                    $"CALLED FROM: {file}:{callerLine} ({callerMethod})"
                )
            )
            {
Debug.Log(
    "<color=#78909C>[LiteSQL]</color>\n" +
    $"<color=#9E9E9E>QUERY</color>: {cmd}\n" +
    $"<color=#9E9E9E>DB</color>: {connection.ConnectionString}\n" +
    $"<color=#9E9E9E>CALLER</color>: {file}:{callerLine} ({callerMethod})"
);
            }

            IDbCommand dbcmd = connection.CreateCommand();
            dbcmd.CommandText = cmd;
            if(parameters != null)
            foreach (var p in parameters)
            {
                var param = dbcmd.CreateParameter();
                param.ParameterName = p.name;
                param.Value = p.value ?? DBNull.Value;
                dbcmd.Parameters.Add(param);
            }
            IDataReader reader = dbcmd.ExecuteReader();

            for (int i = 0; i < linesToRead; i++)
                reader.Read();

            return reader;
        }
        public T QueryFirst<T>(
            string cmd,
            int linesToRead = 0,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        ) where T : new()
        {
            using IDataReader reader = Query(cmd, linesToRead, parameters, callerMethod, callerFile, callerLine);

            if (!reader.Read())
                return default;

            return MapReaderToObject<T>(reader);
        }
        public List<T> QueryList<T>(
            string cmd,
            int linesToRead = 0,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        ) where T : new()
        {
            List<T> result = new();

            using IDataReader reader = Query(cmd, linesToRead, parameters, callerMethod, callerFile, callerLine);

            while (reader.Read())
            {
                result.Add(MapReaderToObject<T>(reader));
            }

            return result;
        }
        public List<T> QueryColumn<T>(string cmd)
        {
            List<T> result = new();

            using IDataReader reader = Query(cmd);

            while (reader.Read())
            {
                object value = reader.GetValue(0);

                if (value == null || value == DBNull.Value)
                    continue;

                result.Add((T)Convert.ChangeType(value, typeof(T)));
            }

            return result;
        }
        public T QueryValue<T>(
            string cmd,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            using IDataReader reader = Query(cmd, 0, parameters, callerMethod, callerFile, callerLine);

            if (!reader.Read())
                return default;

            object value = reader.IsDBNull(0)
                ? null
                : reader.GetValue(0);

            if (value == null)
                return default;

            return (T)Convert.ChangeType(value, typeof(T));
        }
        public Dictionary<TKey, TValue> QueryDictionary<TKey, TValue>(
            string cmd,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            Dictionary<TKey, TValue> result = new();

            using IDataReader reader = Query(cmd, 0, parameters, callerMethod, callerFile, callerLine);

            while (reader.Read())
            {
                TKey key = (TKey)Convert.ChangeType(reader.GetValue(0), typeof(TKey));
                TValue value = (TValue)Convert.ChangeType(reader.GetValue(1), typeof(TValue));

                result[key] = value;
            }

            return result;
        }
        public void Execute(
            string cmd,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            string file = System.IO.Path.GetFileName(callerFile);
            if (!ShouldIgnoreLog(
                    $"LiteSQL request\n" +
                    $"QUERY: {cmd}\n" +
                    $"DB: {connection.ConnectionString}\n" +
                    $"CALLED FROM: {file}:{callerLine} ({callerMethod})"
                )
            )
            {
Debug.Log(
    "<color=#78909C>[LiteSQL]</color>\n" +
    $"<color=#9E9E9E>QUERY</color>: {cmd}\n" +
    $"<color=#9E9E9E>DB</color>: {connection.ConnectionString}\n" +
    $"<color=#9E9E9E>CALLER</color>: {file}:{callerLine} ({callerMethod})"
);
            }
            using var dbcmd = connection.CreateCommand();
            if(parameters != null)
            foreach (var p in parameters)
            {
                var param = dbcmd.CreateParameter();
                param.ParameterName = p.name;
                param.Value = p.value ?? DBNull.Value;
                dbcmd.Parameters.Add(param);
            }
            dbcmd.CommandText = cmd;
            dbcmd.ExecuteNonQuery();
        }
        public bool Exists(
            string cmd,
            (string name, object value)[]? parameters = null,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            using IDataReader reader = Query(cmd, 0, parameters, callerMethod, callerFile, callerLine);
            return reader.Read();
        }
        private static T MapReaderToObject<T>(IDataReader reader)
            where T : new()
        {
            T item = new();

            var properties = typeof(T)
                .GetProperties(BindingFlags.Public |
                               BindingFlags.Instance);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);

                var property = properties.FirstOrDefault(p =>
                    string.Equals(
                        p.Name,
                        columnName,
                        StringComparison.OrdinalIgnoreCase));

                if (property == null || !property.CanWrite)
                    continue;

                object value = reader.IsDBNull(i)
                    ? null
                    : reader.GetValue(i);

                try
                {
                    if (value != null)
                    {
                        Type targetType =
                            Nullable.GetUnderlyingType(property.PropertyType)
                            ?? property.PropertyType;

                        value = Convert.ChangeType(value, targetType);
                    }

                    property.SetValue(item, value);
                }
                catch
                {
                }
            }

            return item;
        }
    }
}