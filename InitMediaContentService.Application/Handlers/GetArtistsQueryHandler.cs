using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetArtistsQueryHandler : IRequestHandler<GetArtistsQuery, IEnumerable<ArtistDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArtistMapper _artistMapper;
        public GetArtistsQueryHandler(IUnitOfWork unitOfWork, ArtistMapper artistMapper)
        {
            _unitOfWork = unitOfWork;
            _artistMapper = artistMapper;
        }
        public async Task<IEnumerable<ArtistDTO>> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
        {
            var artists = await _unitOfWork.ArtistRepository.GetAllAsync(cancellationToken);
            return artists.Select(artist => _artistMapper.ArtistToArtistDTO(artist));
        }
    }
}
