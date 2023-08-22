using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleaseByIdQueryHandler : IRequestHandler<GetReleaseByIdQuery, ReleaseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        public GetReleaseByIdQueryHandler(IUnitOfWork unitOfWork, ReleaseMapper releaseMapper)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
        }
        public async Task<ReleaseDto> Handle(GetReleaseByIdQuery request, CancellationToken cancellationToken)
        {
            return _releaseMapper.ReleaseToReleaseDto(
                await _unitOfWork.ReleaseRepository.FindByIdAsync(request.id, cancellationToken)
                );
        }
    }
}
