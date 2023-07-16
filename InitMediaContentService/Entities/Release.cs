namespace InitMediaContentService.Entities
{
    public class Release
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
