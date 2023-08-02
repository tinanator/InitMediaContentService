using InitMediaContentService.Commands;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class AddArtistHandler : IRequestHandler<AddArtistCommand>
    {
        private readonly IRepository<Artist> _trackRepository;
        public AddArtistHandler(IRepository<Artist> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            return _trackRepository.InsertAsync(request.artist, cancellationToken);
        }
    }
}
