using FlakeId;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddArtistCommandHandler : IRequestHandler<AddArtistCommand, ArtistDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArtistMapper _artistMapper;
        public AddArtistCommandHandler(IUnitOfWork unitOfWork, ArtistMapper artistMapper)
        {
            _unitOfWork = unitOfWork;
            _artistMapper = artistMapper;
        }
        public async Task<ArtistDTO> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            request.artistDTO.Id = Id.Create();
            var insertedArtist = _unitOfWork.ArtistRepository.Insert(_artistMapper.ArtistDTOToArtist(request.artistDTO));
            await _unitOfWork.SaveAsync(cancellationToken);

            return _artistMapper.ArtistToArtistDTO(insertedArtist.Entity);
        }
    }
}
