using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Commands
{
    public record AddReleaseCommand(Release release) : IRequest
    {
    }
}
