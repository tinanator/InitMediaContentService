using InitMediaContentService.Commands;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;

namespace InitMediaContentService.Handlers
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
