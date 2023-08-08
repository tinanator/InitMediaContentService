using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
