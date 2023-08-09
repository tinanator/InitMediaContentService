using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleaseByIdHandler : IRequestHandler<GetReleaseByIdQuery, ReleaseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        public GetReleaseByIdHandler(IUnitOfWork unitOfWork, ReleaseMapper releaseMapper)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
        }
        public async Task<ReleaseDTO> Handle(GetReleaseByIdQuery request, CancellationToken cancellationToken)
        {
            return _releaseMapper.ReleaseToReleaseDTO(
                await _unitOfWork.ReleaseRepository.FindByIdAsync(request.id, cancellationToken)
                );
        }
    }
}
