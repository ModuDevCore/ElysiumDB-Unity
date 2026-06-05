using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class AuthElysiumDB : DBExtensionBase
{
    public bool IsAuthenticated { get; private set; }
    public string CurrentJWT { get; private set; }

    private IAuthElysiumReceiver[] _receivers => GetExtensions<IAuthElysiumReceiver>();

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Debug.Log("AuthElysiumDB initialized");
    }

    protected override void OnDispose()
    {
    }

    public void Auth(string newJwt) {
        PlayerPrefs.SetString("ElysiumSession", newJwt);
        NotifyAuthTokenUpdated(newJwt);
    }
    public string GetJWT() {
        return PlayerPrefs.GetString("ElysiumSession");
    }

    void NotifyAuthTokenUpdated(string newJwt) {
        foreach(IAuthElysiumReceiver iaer in _receivers)
            iaer.OnAuthTokenUpdated(newJwt);
    }
}