using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteReleaseByIdCommand(int id) : IRequest
    {
    }
}
