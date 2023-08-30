using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using AWS.Lambda.Powertools.Logging;
using Microsoft.EntityFrameworkCore.Storage;
using System.Configuration;

namespace InitMediaContentService
{
    public static class AWSSecretManager
    {
        public static async Task<string> GetSecret()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var loggerOptions = new LambdaLoggerOptions(configuration);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddLambdaLogger(loggerOptions);
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddDebug();
            });

            var logger = loggerFactory.CreateLogger<Program>();

            string secretName = "prod/initMediaContent/DB";
            string region = "us-east-1";

            logger.LogDebug("Getting secret");

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            logger.LogDebug("Getting client");

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            logger.LogDebug("Making a request");

            GetSecretValueResponse response;

            try
            {
                logger.LogDebug("trying to get response");
                response = await client.GetSecretValueAsync(request);
                logger.LogDebug(response.ToString());
            }
            catch (Exception e)
            {
                logger.LogError("something wrong");
                throw e;
            }

            return response.SecretString;
        }
    }
}
