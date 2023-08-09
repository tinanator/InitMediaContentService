using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddReleaseHandler : IRequestHandler<AddReleaseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        public AddReleaseHandler(IUnitOfWork unitOfWork, ReleaseMapper releaseMapper)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
        }
        public async Task Handle(AddReleaseCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ReleaseRepository.InsertAsync(_releaseMapper.ReleaseDTOToRelease(request.releaseDTO));
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
