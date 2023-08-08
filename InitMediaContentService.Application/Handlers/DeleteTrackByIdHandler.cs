using InitMediaContentService.Application.Commands;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class DeleteTrackByIdHandler : IRequestHandler<DeleteTrackByIdCommand>
    {
        private readonly UnitOfWork _unitOfWork;
        public DeleteTrackByIdHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteTrackByIdCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ArtistRepository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
