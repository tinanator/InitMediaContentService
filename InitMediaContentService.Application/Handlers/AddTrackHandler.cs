using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
