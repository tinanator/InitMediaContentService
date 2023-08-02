using MediatR;

namespace InitMediaContentService.Commands
{
    public record DeleteReleaseByIdCommand(int id) : IRequest
    {
    }
}
