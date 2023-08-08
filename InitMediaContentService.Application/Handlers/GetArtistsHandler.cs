using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetArtistsHandler : IRequestHandler<GetArtistsQuery, IEnumerable<Artist>>
    {
        private readonly IRepository<Artist> _trackRepository;
        public GetArtistsHandler(IRepository<Artist> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task<IEnumerable<Artist>> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
        {
            return _trackRepository.GetAllAsync(cancellationToken);
        }
    }
}
