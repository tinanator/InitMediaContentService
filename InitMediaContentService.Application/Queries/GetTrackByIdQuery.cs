using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetTrackByIdQuery(int id) : IRequest<Track>
    {
    }
}
