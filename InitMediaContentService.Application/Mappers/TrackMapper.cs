using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace InitMediaContentService.Application.Mappers
{
    [Mapper]
    public partial class TrackMapper
    {
        public partial TrackDto TrackToTrackDTO(Track track);

        public partial Track TrackDTOToTrack(TrackDto trackDTO);
    }
}
