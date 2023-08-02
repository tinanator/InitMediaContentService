using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Queries
{
    public record GetArtistByIdQuery(int id) : IRequest<Artist>
    {

    }
}
