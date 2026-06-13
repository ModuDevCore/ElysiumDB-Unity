using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class AuthElysiumDB : DBExtensionBase
{
    public string cacheFileName = "elysium_session.cache";
    public bool IsAuthenticated { get; private set; }

    private IAuthElysiumReceiver[] _receivers => GetExtensions<IAuthElysiumReceiver>();

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Debug.Log("AuthElysiumDB initialized");
    }

    protected override void OnDispose()
    {
    }

    public void Auth(string сredentials) {
        PlayerPrefs.SetString(cacheFileName, сredentials);
        NotifyAuthTokenUpdated(сredentials);
    }
    public void SignOut() {
        PlayerPrefs.DeleteKey(cacheFileName);
    }
    public string GetCredentials() {
        return PlayerPrefs.GetString(cacheFileName);
    }

    void NotifyAuthTokenUpdated(string newJwt) {
        foreach(IAuthElysiumReceiver iaer in _receivers)
            iaer.OnAuthTokenUpdated(newJwt);
    }
}