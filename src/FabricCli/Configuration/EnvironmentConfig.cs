using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FabricCli.Configuration
{
    public static class EnvironmentConfig
    {
        public static string GetUsername()
        {
            return GetEnvironmentVariable("AZURE_USERNAME");
        }

        public static SecureString GetSecurePassword()
        {
            string password = GetEnvironmentVariable("AZURE_PASSWORD");
            SecureString securePassword = new SecureString();

            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            return securePassword;
        }

        private static string GetEnvironmentVariable(string variableName)
        {
            string value = Environment.GetEnvironmentVariable(variableName);

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"Environment variable '{variableName}' is not set.");
            }

            return value;
        }
    }
}
