using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetArtistByIdQuery(int id) : IRequest<ArtistDTO>
    {
    }
}
