using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteReleaseByIdCommand(Guid id) : IRequest
    {
    }
}
