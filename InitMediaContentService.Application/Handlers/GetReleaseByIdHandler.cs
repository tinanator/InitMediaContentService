using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
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
