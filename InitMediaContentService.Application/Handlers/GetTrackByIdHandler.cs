using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, TrackDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        public GetTrackByIdHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
        }
        public async Task<TrackDTO> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            return _trackMapper.TrackToTrackDTO(
                await _unitOfWork.TrackRepository.FindByIdAsync(request.id, cancellationToken)
                );
        }
    }
}
