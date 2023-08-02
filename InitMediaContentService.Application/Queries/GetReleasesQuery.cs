using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Queries
{
    public record GetReleasesQuery() : IRequest<IEnumerable<Release>>
    {
    }
}
