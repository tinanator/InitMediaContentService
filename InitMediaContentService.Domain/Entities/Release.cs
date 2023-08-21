using MassTransit;

namespace InitMediaContentService.Domain.Entities
{
    public class Release
    {
        public long ClusterId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }

        #region Navigation Properties

        public long ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }

        #endregion
    }
}
