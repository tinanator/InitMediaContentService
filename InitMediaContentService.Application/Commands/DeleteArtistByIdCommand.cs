using MediatR;

namespace InitMediaContentService.Commands
{
    public record DeleteArtistByIdCommand(int id) : IRequest
    {
    }
}
