using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteArtistByIdCommand(long id) : IRequest
    {
    }
}
