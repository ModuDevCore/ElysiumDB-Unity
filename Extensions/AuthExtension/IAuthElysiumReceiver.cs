using System.Threading.Tasks;
using ModuDevCore.ElysiumDB;
using Newtonsoft.Json.Linq;

public interface IAuthElysiumReceiver
{
    public void OnAuthTokenUpdated(string newJwt);

    public void OnAuthLoggedOut();

    public Task OnFetchAuthUserData(DBMeta authTable);
}