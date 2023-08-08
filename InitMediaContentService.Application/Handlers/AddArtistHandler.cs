using InitMediaContentService.Application.Commands;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddArtistHandler : IRequestHandler<AddArtistCommand>
    {
        private readonly UnitOfWork _unitOfWork;
        public AddArtistHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ArtistRepository.InsertAsync(request.artist);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
