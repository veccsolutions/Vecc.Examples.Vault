using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace Vecc.Examples.Vault
{
    public class DottableKeyVaultSecretManager : DefaultKeyVaultSecretManager
    {
        public override string GetKey(SecretBundle secret)
        {
            var result = secret.SecretIdentifier.Name.Replace("---", ".").Replace("--", ConfigurationPath.KeyDelimiter);

            return result;
        }
    }
}
