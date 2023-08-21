using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteTrackByIdCommand(long id) : IRequest
    {
    }
}
