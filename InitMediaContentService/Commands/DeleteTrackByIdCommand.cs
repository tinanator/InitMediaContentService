using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Commands
{
    public record DeleteTrackByIdCommand(int id) : IRequest
    {
    }
}
