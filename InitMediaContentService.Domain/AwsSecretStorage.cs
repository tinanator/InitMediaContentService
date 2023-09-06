using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace InitMediaContentService.Domain
{
    public class AwsSecretStorage : ISecretStorage
    {
        private readonly ILogger _logger;
        public AwsSecretStorage()
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

            _logger = loggerFactory.CreateLogger<AwsSecretStorage>();
        }
        public async Task<string> GetSecret(string secretName)
        {
            string region = "us-east-1";

            _logger.LogDebug("Getting secret");

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            _logger.LogDebug("Getting client");

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            _logger.LogDebug("Making a request");

            GetSecretValueResponse response;

            try
            {
                _logger.LogDebug("trying to get response");
                response = await client.GetSecretValueAsync(request);
                _logger.LogDebug(response.ToString());
            }
            catch (Exception e)
            {
                _logger.LogError("something wrong");
                throw e;
            }

            return response.SecretString;
        }
    }
}
