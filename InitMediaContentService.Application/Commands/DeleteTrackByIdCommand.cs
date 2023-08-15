using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteTrackByIdCommand(Guid id) : IRequest
    {
    }
}
