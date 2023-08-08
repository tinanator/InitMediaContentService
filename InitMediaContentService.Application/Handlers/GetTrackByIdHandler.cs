using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, Track>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetTrackByIdHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Track> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.TrackRepository.FindByIdAsync(request.id, cancellationToken);
        }
    }
}
