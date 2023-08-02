using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Queries
{
    public record GetTracksQuery() : IRequest<IEnumerable<Track>>
    {
    }
}
