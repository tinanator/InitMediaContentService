
namespace InitMediaContentService.Application.Exceptions
{
    public class ReleaseNotFoundException : Exception
    {
        public ReleaseNotFoundException() : base() { }
        public ReleaseNotFoundException(string message) : base(message) { }
        public ReleaseNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
