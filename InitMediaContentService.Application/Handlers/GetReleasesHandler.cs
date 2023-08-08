using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleasesHandler : IRequestHandler<GetReleasesQuery, IEnumerable<Release>>
    {
        private readonly IRepository<Release> _trackRepository;
        public GetReleasesHandler(IRepository<Release> trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public Task<IEnumerable<Release>> Handle(GetReleasesQuery request, CancellationToken cancellationToken)
        {
            return _trackRepository.GetAllAsync(cancellationToken);
        }
    }
}
