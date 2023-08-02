using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Queries
{
    public record GetArtistsQuery() : IRequest<IEnumerable<Artist>>
    {
    }
}
