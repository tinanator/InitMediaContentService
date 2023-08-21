using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddReleaseCommand(ReleaseDto releaseDTO) : IRequest<ReleaseDto>
    {
    }
}
