using domain.interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

namespace infra.services
{
    public class GoogleCredentialProvider : IGoogleCredentialProvider
    {
        private readonly string _credentialsPath;
        private readonly string _tokenPath;

        public GoogleCredentialProvider(string credentialsPath, string tokenPath)
        {
            _credentialsPath = credentialsPath;
            _tokenPath = tokenPath;
        }
        public UserCredential GetUserCredential()
        {
            using var stream = new FileStream(_credentialsPath, FileMode.Open, FileAccess.Read);

            return GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new[] { "https://www.googleapis.com/auth/calendar" },
                "user",
                CancellationToken.None,
                new FileDataStore(_tokenPath, true)
            ).Result;
        }
    }
}
