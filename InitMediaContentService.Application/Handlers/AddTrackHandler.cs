using InitMediaContentService.Application.Commands;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddTrackHandler : IRequestHandler<AddTrackCommand>
    {
        private readonly UnitOfWork _unitOfWork;
        public AddTrackHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.TrackRepository.InsertAsync(request.track);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
