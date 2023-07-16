using InitMediaContentService.Database;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class GetTracksHandler : IRequestHandler<GetTracksQuery, IEnumerable<Track>>
    {
        private readonly IRepository<Track> _trackRepository;
        public GetTracksHandler(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task<IEnumerable<Track>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            return _trackRepository.GetAllAsync(cancellationToken);
        }
    }
}
