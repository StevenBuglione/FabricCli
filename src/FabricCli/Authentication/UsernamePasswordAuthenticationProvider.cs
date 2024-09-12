using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FabricCli.Authentication
{
    public class UsernamePasswordAuthenticationProvider 
    {
        private readonly string _username;
        private readonly SecureString _password;
        private readonly IPublicClientApplication _app;
        private readonly string[] _scopes;

        public UsernamePasswordAuthenticationProvider(string username, SecureString password)
        {
            _username = username;
            _password = password;
            _scopes = GetFabricScopes();
            _app = BuildPublicClientApplication();
        }

        public AuthenticationResult AcquireToken()
        {
            return AcquireTokenWithUsernamePassword();
        }

        private IPublicClientApplication BuildPublicClientApplication()
        {
            const string ClientId = "56b4b6bd-f36a-45c3-b38a-61391b32f2f5";
            const string authority = "https://login.microsoftonline.com/organizations";

            return PublicClientApplicationBuilder.Create(ClientId)
                .WithAuthority(authority)
                .Build();
        }

        private string[] GetFabricScopes()
        {
            return new string[]
            {
            "https://api.fabric.microsoft.com/Workspace.ReadWrite.All",
            "https://api.fabric.microsoft.com/Item.ReadWrite.All"
            };
        }

        private AuthenticationResult AcquireTokenWithUsernamePassword()
        {
            try
            {
                return _app.AcquireTokenByUsernamePassword(_scopes, _username, _password)
                    .ExecuteAsync().GetAwaiter().GetResult();
            }
            catch (MsalException ex)
            {
                Console.WriteLine($"Error acquiring token with username/password: {ex.Message}");
                throw;
            }
        }
    }
}
