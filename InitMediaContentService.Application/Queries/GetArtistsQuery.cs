using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetArtistsQuery() : IRequest<IEnumerable<Artist>>
    {
    }
}
