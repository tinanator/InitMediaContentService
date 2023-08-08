using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetTracksQuery() : IRequest<IEnumerable<Track>>
    {
    }
}
