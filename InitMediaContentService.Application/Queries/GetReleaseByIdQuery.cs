using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetReleaseByIdQuery(int id) : IRequest<Release>
    {
    }
}
