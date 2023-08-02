using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class DeleteReleaseByIdHandler : IRequestHandler<DeleteReleaseByIdCommand>
    {
        private readonly IRepository<Release> _trackRepository;
        public DeleteReleaseByIdHandler(IRepository<Release> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task Handle(DeleteReleaseByIdCommand request, CancellationToken cancellationToken)
        {
            return _trackRepository.DeleteAsync(request.id, cancellationToken);
        }
    }
}
