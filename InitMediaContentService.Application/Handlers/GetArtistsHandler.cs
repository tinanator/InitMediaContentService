using InitMediaContentService.Commands;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;

namespace InitMediaContentService.Handlers
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
