using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetTracksQuery() : IRequest<IEnumerable<TrackDTO>>
    {
    }
}
