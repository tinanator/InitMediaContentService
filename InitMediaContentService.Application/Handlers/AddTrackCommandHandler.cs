using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public AddTrackCommandHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            request.trackDTO.Id = NewId.NextGuid();
            _unitOfWork.TrackRepository.Insert(_trackMapper.TrackDTOToTrack(request.trackDTO));
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
