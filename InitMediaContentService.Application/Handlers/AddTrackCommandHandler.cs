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
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, TrackDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackMapper _trackMapper;
        private readonly IValidator<TrackDto> _trackValidator;
        public AddTrackCommandHandler(IUnitOfWork unitOfWork, TrackMapper trackMapper, IValidator<TrackDto> trackValidator)
        {
            _unitOfWork = unitOfWork;
            _trackMapper = trackMapper;
            _trackValidator = trackValidator;
        }
        public async Task<TrackDto> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await _trackValidator.ValidateAsync(request.trackDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.ToString());
            }

            request.trackDto.Id = Id.Create();
            var insertedTrack = _unitOfWork.TrackRepository.Insert(_trackMapper.TrackDtoToTrack(request.trackDto));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _trackMapper.TrackToTrackDto(insertedTrack.Entity);
        }
    }
}
