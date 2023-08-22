
namespace InitMediaContentService.Application.Exceptions
{
    public class TrackNotFoundException : Exception
    {
        public TrackNotFoundException() : base() { }
        public TrackNotFoundException(string message) : base(message) { }
        public TrackNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
