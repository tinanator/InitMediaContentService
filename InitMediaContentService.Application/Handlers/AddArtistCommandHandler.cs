using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddArtistCommandHandler : IRequestHandler<AddArtistCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArtistMapper _artistMapper;
        public AddArtistCommandHandler(IUnitOfWork unitOfWork, ArtistMapper artistMapper)
        {
            _unitOfWork = unitOfWork;
            _artistMapper = artistMapper;
        }
        public async Task Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ArtistRepository.Insert(_artistMapper.ArtistDTOToArtist(request.artistDTO));
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
