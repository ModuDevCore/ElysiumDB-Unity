using ModuDevCore.ElysiumDB;
using Newtonsoft.Json.Linq;

public interface IAuthElysiumReceiver
{
    public void OnAuthTokenUpdated(string newJwt);

    public void OnAuthLoggedOut();

    public void OnFetchAuthUserData(DBMeta authTable);
}