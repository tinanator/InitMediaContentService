using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddTrackCommand(TrackDto trackDTO) : IRequest<TrackDto>
    {
    }
}
