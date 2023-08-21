using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteReleaseByIdCommand(long id) : IRequest
    {
    }
}
