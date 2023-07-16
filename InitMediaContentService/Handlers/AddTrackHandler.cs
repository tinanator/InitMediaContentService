using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class AddTrackHandler : IRequestHandler<AddTrackCommand>
    {
        private readonly IRepository<Track> _trackRepository;
        public AddTrackHandler(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            return _trackRepository.InsertAsync(request.track, cancellationToken);
        }
    }
}
