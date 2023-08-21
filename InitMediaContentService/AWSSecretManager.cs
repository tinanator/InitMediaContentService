using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace InitMediaContentService
{
    public static class AWSSecretManager
    {
        public static async Task<string> GetSecret()
        {
            string secretName = "prod/initMediaContent/DB";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }

            return response.SecretString;
        }
    }
}
