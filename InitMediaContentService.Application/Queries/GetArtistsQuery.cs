using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetArtistsQuery() : IRequest<IEnumerable<ArtistDto>>
    {
    }
}
