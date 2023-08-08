using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTracksHandler : IRequestHandler<GetTracksQuery, IEnumerable<Track>>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetTracksHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Track>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.TrackRepository.GetAllAsync(cancellationToken);
        }
    }
}
