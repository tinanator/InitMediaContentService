using FlakeId;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddReleaseCommandHandler : IRequestHandler<AddReleaseCommand, ReleaseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        public AddReleaseCommandHandler(IUnitOfWork unitOfWork, ReleaseMapper releaseMapper)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
        }
        public async Task<ReleaseDto> Handle(AddReleaseCommand request, CancellationToken cancellationToken)
        {
            request.releaseDTO.Id = Id.Create();
            var insertedRelease = _unitOfWork.ReleaseRepository.Insert(_releaseMapper.ReleaseDTOToRelease(request.releaseDTO));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _releaseMapper.ReleaseToReleaseDTO(insertedRelease.Entity);
        }
    }
}
