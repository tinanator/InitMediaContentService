using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleasesQueryHandler : IRequestHandler<GetReleasesQuery, IEnumerable<ReleaseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        public GetReleasesQueryHandler(IUnitOfWork unitOfWork, ReleaseMapper releaseMapper)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
        }
        public async Task<IEnumerable<ReleaseDto>> Handle(GetReleasesQuery request, CancellationToken cancellationToken)
        {
            var releases = await _unitOfWork.ReleaseRepository.GetAllAsync(cancellationToken);
            return releases.Select(release => _releaseMapper.ReleaseToReleaseDTO(release));
        }
    }
}
