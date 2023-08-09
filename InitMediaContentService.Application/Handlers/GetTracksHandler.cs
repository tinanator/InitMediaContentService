using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTracksHandler : IRequestHandler<GetTracksQuery, IEnumerable<TrackDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public GetTracksHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task<IEnumerable<TrackDTO>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            var tracks = await _unitOfWork.TrackRepository.GetAllAsync(cancellationToken);
            return tracks.Select(track => _trackMapper.TrackToTrackDTO(track));
        }
    }
}
