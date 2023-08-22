
namespace InitMediaContentService.Application.Exceptions
{
    public class ArtistNotFoundException : Exception
    {
        public ArtistNotFoundException() : base() { }
        public ArtistNotFoundException(string message) : base(message) { }
        public ArtistNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
