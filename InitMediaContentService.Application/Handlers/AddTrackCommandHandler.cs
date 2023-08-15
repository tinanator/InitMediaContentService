﻿using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, TrackDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public AddTrackCommandHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task<TrackDTO> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            request.trackDTO.Id = NewId.NextGuid();
            var insertedTrack = _unitOfWork.TrackRepository.Insert(_trackMapper.TrackDTOToTrack(request.trackDTO));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _trackMapper.TrackToTrackDTO(insertedTrack.Entity);
        }
    }
}