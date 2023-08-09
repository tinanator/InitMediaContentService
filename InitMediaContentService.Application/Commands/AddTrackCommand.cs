using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddTrackCommand(TrackDTO trackDTO) : IRequest
    {
    }
}
