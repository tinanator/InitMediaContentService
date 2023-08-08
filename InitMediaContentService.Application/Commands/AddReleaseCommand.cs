using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddReleaseCommand(Release release) : IRequest
    {
    }
}
