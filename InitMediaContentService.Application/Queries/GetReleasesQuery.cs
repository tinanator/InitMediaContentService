using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetReleasesQuery() : IRequest<IEnumerable<Release>>
    {
    }
}
