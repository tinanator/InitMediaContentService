using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Exceptions;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTrackByIdQueryHandler : IRequestHandler<GetTrackByIdQuery, TrackDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        private readonly ILogger _logger;
        public GetTrackByIdQueryHandler(ILogger<Track> logger, IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
            _logger = logger;
        }
        public async Task<TrackDto> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting Track with id = {request.id}");

            var track = await _unitOfWork.TrackRepository.FindByIdAsync(request.id, cancellationToken);

            if (track == null)
            {
                _logger.LogError($"In GetTrackById Track with id = {request.id} not found");
                throw new TrackNotFoundException($"track with id = {request.id} not found");
            }

            _logger.LogInformation($"Getting Track with id = {request.id}");

            return _trackMapper.TrackToTrackDto(track);
        }
    }
}
