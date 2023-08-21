
using MassTransit;

namespace InitMediaContentService.Domain.Entities
{
    public class Artist
    {
        public long ClusterId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Release> Releases { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
