using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace InitMediaContentService
{
    public interface ISecretStorage
    {
        Task<string> GetSecret(string secretName);
    }
}
