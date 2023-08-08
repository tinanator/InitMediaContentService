using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleaseByIdHandler : IRequestHandler<GetReleaseByIdQuery, Release>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetReleaseByIdHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Release> Handle(GetReleaseByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ReleaseRepository.FindByIdAsync(request.id, cancellationToken);
        }
    }
}
