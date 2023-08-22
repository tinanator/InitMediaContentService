using FlakeId;
using FluentValidation;
using FluentValidation.Results;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Validators;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddReleaseCommandHandler : IRequestHandler<AddReleaseCommand, ReleaseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        private readonly IValidator<ReleaseDto> _releaseValidator;
        public AddReleaseCommandHandler(IUnitOfWork unitOfWork, ReleaseMapper releaseMapper, IValidator<ReleaseDto> releaseValidator)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
            _releaseValidator = releaseValidator;
        }
        public async Task<ReleaseDto> Handle(AddReleaseCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await _releaseValidator.ValidateAsync(request.releaseDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.ToString());
            }

            request.releaseDto.Id = Id.Create();
            var insertedRelease = _unitOfWork.ReleaseRepository.Insert(_releaseMapper.ReleaseDtoToRelease(request.releaseDto));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _releaseMapper.ReleaseToReleaseDto(insertedRelease.Entity);
        }
    }
}
