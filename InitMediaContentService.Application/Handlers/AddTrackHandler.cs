using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddTrackHandler : IRequestHandler<AddTrackCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public AddTrackHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.TrackRepository.InsertAsync(_trackMapper.TrackDTOToTrack(request.trackDTO));
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
