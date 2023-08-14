using InitMediaContentService.Domain.Interfaces;
using MediatR;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;

namespace InitMediaContentService.Application.Handlers
{
    public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArtistMapper _artistMapper;
        public GetArtistByIdQueryHandler(IUnitOfWork unitOfWork, ArtistMapper artistMapper)
        {
            _unitOfWork = unitOfWork;
            _artistMapper = artistMapper;
        }
        public async Task<ArtistDTO> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            return _artistMapper.ArtistToArtistDTO(
                await _unitOfWork.ArtistRepository.FindByIdAsync(request.id, cancellationToken)
                );
        }
    }
}
