using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Queries
{
    public record GetReleaseByIdQuery(int id) : IRequest<Release>
    {
    }
}
