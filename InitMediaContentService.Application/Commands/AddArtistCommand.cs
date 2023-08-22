using InitMediaContentService.Application.DTOs;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddArtistCommand(ArtistDto artistDto) : IRequest<ArtistDto>
    {
    }
}
