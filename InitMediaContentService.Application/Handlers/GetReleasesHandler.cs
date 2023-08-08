using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleasesHandler : IRequestHandler<GetReleasesQuery, IEnumerable<Release>>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetReleasesHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Release>> Handle(GetReleasesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ReleaseRepository.GetAllAsync(cancellationToken);
        }
    }
}
