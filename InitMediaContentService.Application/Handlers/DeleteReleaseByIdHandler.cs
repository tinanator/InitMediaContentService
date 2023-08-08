using InitMediaContentService.Application.Commands;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class DeleteReleaseByIdHandler : IRequestHandler<DeleteReleaseByIdCommand>
    {
        private readonly UnitOfWork _unitOfWork;
        public DeleteReleaseByIdHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteReleaseByIdCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ArtistRepository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
