using InitMediaContentService.Domain.Entities;
using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record AddArtistCommand(Artist artist) : IRequest
    {
    }
}
