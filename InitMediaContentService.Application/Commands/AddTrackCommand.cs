using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Commands
{
    public record AddTrackCommand(Track track) : IRequest
    {
    }
}
