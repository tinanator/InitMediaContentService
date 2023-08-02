using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, Track>
    {
        private readonly IRepository<Track> _trackRepository;
        public GetTrackByIdHandler(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task<Track> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            return _trackRepository.FindByIdAsync(request.id, cancellationToken);
        }
    }
}
