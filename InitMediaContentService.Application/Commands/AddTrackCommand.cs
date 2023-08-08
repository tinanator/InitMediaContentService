using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddTrackCommand(Track track) : IRequest
    {
    }
}
