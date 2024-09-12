using Azure.Core;
using Azure.Identity;
using FabricCli.Authentication;
using FabricCli.Configuration;
using Microsoft.Fabric.Api;
using Microsoft.Identity.Client;
using System.Security;

namespace FabricCli.Factory
{
    public class FabricClientFactory
    {
        public FabricClientFactory() { }

        public FabricClient CreateServiceProviderFabricClient()
        {
            TokenCredential credential = new EnvironmentCredential();

            string[] scopes = ["https://api.fabric.microsoft.com/.default"];

            TokenRequestContext context = new TokenRequestContext(scopes);

            AccessToken accessToken = credential.GetToken(context, CancellationToken.None);

            return new FabricClient(accessToken.Token);
        }

        public FabricClient CreateUsernamePasswordFabricClient()
        {
            string username = EnvironmentConfig.GetUsername();
            SecureString password = EnvironmentConfig.GetSecurePassword();

            UsernamePasswordAuthenticationProvider authProvider = new UsernamePasswordAuthenticationProvider(username, password);
            AuthenticationResult tokenResult = authProvider.AcquireToken();

            if (tokenResult == null)
            {
                throw new Exception("Failed to acquire token.");
            }

            return new FabricClient(tokenResult.AccessToken);
        }

    }


}
