using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetTrackByIdQuery(long id) : IRequest<TrackDTO>
    {
    }
}
