using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace InitMediaContentService.Application.Mappers
{
    [Mapper]
    public partial class TrackMapper
    {
        public partial TrackDto TrackToTrackDto(Track track);

        public partial Track TrackDtoToTrack(TrackDto trackDto);
    }
}
