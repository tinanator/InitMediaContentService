using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Domain.Entities;
using MediatR;
using InitMediaContentService.Application.Queries;

namespace InitMediaContentService.Application.Handlers
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
