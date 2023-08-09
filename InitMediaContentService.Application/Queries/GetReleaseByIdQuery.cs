using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Queries
{
    public record GetReleaseByIdQuery(int id) : IRequest<ReleaseDTO>
    {
    }
}
