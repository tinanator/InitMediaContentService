using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetReleaseByIdQuery(Guid id) : IRequest<ReleaseDTO>
    {
    }
}
