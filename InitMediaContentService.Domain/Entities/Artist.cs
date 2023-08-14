﻿
namespace InitMediaContentService.Domain.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Release> Releases { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
