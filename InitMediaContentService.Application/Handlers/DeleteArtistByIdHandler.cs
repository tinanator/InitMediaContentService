using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
