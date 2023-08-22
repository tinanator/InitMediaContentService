using Riok.Mapperly.Abstractions;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Domain.Entities;

namespace InitMediaContentService.Application.Mappers
{
    [Mapper]
    public partial class ArtistMapper
    {
        public partial ArtistDto ArtistToArtistDto(Artist artist);

        public partial Artist ArtistDtoToArtist(ArtistDto astistDto);
    }
}
