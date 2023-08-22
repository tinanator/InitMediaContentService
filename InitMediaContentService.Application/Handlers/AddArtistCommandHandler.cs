using FlakeId;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;
using FluentValidation;
using FluentValidation.Results;
using InitMediaContentService.Application.Validators;
using System;

namespace InitMediaContentService.Application.Handlers
{
    public class AddArtistCommandHandler : IRequestHandler<AddArtistCommand, ArtistDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArtistMapper _artistMapper;
        private readonly IValidator<ArtistDto> _artistValidator;
        public AddArtistCommandHandler(IUnitOfWork unitOfWork, ArtistMapper artistMapper, IValidator<ArtistDto> artistValidator)
        {
            _unitOfWork = unitOfWork;
            _artistMapper = artistMapper;
            _artistValidator = artistValidator;
        }
        public async Task<ArtistDto> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await _artistValidator.ValidateAsync(request.artistDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.ToString());
            }

            request.artistDto.Id = Id.Create();
            var insertedArtist = _unitOfWork.ArtistRepository.Insert(_artistMapper.ArtistDtoToArtist(request.artistDto));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _artistMapper.ArtistToArtistDto(insertedArtist.Entity);
        }
    }
}
