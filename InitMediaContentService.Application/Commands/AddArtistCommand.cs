using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Commands
{
    public record AddArtistCommand(Artist artist) : IRequest
    {
    }
}
