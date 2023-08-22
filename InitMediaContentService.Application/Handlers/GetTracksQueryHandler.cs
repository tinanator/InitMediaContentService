using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, IEnumerable<TrackDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public GetTracksQueryHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task<IEnumerable<TrackDto>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            var tracks = await _unitOfWork.TrackRepository.GetAllAsync(cancellationToken);
            return tracks.Select(track => _trackMapper.TrackToTrackDto(track));
        }
    }
}
