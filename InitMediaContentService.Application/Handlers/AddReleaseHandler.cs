using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
