using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitMediaContentService.Domain
{
    public class LocalSecretStorage : ISecretStorage
    {
        private readonly IConfiguration _configuration;
        public LocalSecretStorage(WebApplicationBuilder builder)
        {
            _configuration = builder.Configuration;
        }

        public Task<string> GetSecret(string secretName)
        {
            return Task.FromResult<string>(_configuration.GetConnectionString(secretName));
        }
    }
}
