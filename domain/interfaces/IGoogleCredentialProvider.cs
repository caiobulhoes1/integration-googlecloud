using Google.Apis.Auth.OAuth2;


namespace domain.interfaces
{
    public interface IGoogleCredentialProvider
    {
        UserCredential GetUserCredential();
    }
}
