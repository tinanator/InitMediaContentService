using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Queries
{
    public record GetTrackByIdQuery(int id) : IRequest<Track>
    {
    }
}
