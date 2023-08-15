using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteArtistByIdCommand(Guid id) : IRequest
    {
    }
}
