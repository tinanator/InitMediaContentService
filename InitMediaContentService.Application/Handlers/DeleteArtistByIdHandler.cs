using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class DeleteArtistByIdHandler : IRequestHandler<DeleteArtistByIdCommand>
    {
        private readonly IRepository<Artist> _trackRepository;
        public DeleteArtistByIdHandler(IRepository<Artist> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task Handle(DeleteArtistByIdCommand request, CancellationToken cancellationToken)
        {
            return _trackRepository.DeleteAsync(request.id, cancellationToken);
        }
    }
}
