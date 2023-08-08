using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
