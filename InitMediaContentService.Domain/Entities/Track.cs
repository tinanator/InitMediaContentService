namespace InitMediaContentService.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseId { get; set; }
        public Artist Artist { get; set; }
        public Release Release { get; set; }
    }
}
