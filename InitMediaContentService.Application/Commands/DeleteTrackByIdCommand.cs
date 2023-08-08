using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteTrackByIdCommand(int id) : IRequest
    {
    }
}
