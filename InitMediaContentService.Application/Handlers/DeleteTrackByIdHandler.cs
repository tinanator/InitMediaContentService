using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class DeleteTrackByIdHandler : IRequestHandler<DeleteTrackByIdCommand>
    {
        private readonly IRepository<Track> _trackRepository;
        public DeleteTrackByIdHandler(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task Handle(DeleteTrackByIdCommand request, CancellationToken cancellationToken)
        {
            return _trackRepository.DeleteAsync(request.id, cancellationToken);
        }
    }
}
