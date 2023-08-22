using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddReleaseCommand(ReleaseDto releaseDto) : IRequest<ReleaseDto>
    {
    }
}
