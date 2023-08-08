using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
