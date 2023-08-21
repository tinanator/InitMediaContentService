using MassTransit;

namespace InitMediaContentService.Domain.Entities
{
    public class Track
    {
        public long ClusterId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long ArtistId { get; set; }
        public long ReleaseId { get; set; }
        public Artist Artist { get; set; }
        public Release Release { get; set; }
    }
}
