
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class GetArtistByIdHandler : IRequestHandler<GetArtistByIdQuery, Artist>
    {
        private readonly IRepository<Artist> _trackRepository;
        public GetArtistByIdHandler(IRepository<Artist> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task<Artist> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            return _trackRepository.FindByIdAsync(request.id, cancellationToken);
        }
    }
}
