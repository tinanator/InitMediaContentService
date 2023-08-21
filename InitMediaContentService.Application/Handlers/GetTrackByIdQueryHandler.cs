using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTrackByIdQueryHandler : IRequestHandler<GetTrackByIdQuery, TrackDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public GetTrackByIdQueryHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task<TrackDto> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            return _trackMapper.TrackToTrackDTO(
                await _unitOfWork.TrackRepository.FindByIdAsync(request.id, cancellationToken)
                );
        }
    }
}
