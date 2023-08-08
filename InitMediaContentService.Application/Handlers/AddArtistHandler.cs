using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
