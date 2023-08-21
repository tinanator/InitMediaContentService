using FlakeId;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, TrackDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public AddTrackCommandHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task<TrackDto> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            request.trackDTO.Id = Id.Create();
            var insertedTrack = _unitOfWork.TrackRepository.Insert(_trackMapper.TrackDTOToTrack(request.trackDTO));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _trackMapper.TrackToTrackDTO(insertedTrack.Entity);
        }
    }
}
