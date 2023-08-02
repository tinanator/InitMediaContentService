using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;

namespace InitMediaContentService.Handlers
{
    public class GetReleaseByIdHandler : IRequestHandler<GetReleaseByIdQuery, Release>
    {
        private readonly IRepository<Release> _trackRepository;
        public GetReleaseByIdHandler(IRepository<Release> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task<Release> Handle(GetReleaseByIdQuery request, CancellationToken cancellationToken)
        {
            return _trackRepository.FindByIdAsync(request.id, cancellationToken);
        }
    }
}
