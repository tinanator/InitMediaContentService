using MediatR;

namespace InitMediaContentService.Application.Commands
{
    public record DeleteArtistByIdCommand(int id) : IRequest
    {
    }
}
