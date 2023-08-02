using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class AddReleaseHandler : IRequestHandler<AddReleaseCommand>
    {
        private readonly IRepository<Release> _trackRepository;
        public AddReleaseHandler(IRepository<Release> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task Handle(AddReleaseCommand request, CancellationToken cancellationToken)
        {
            return _trackRepository.InsertAsync(request.release, cancellationToken);
        }
    }
}
