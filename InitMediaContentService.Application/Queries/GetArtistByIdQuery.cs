using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetArtistByIdQuery(Guid id) : IRequest<ArtistDTO>
    {
    }
}
