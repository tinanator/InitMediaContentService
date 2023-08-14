using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class DeleteReleaseByIdCommandHandler : IRequestHandler<DeleteReleaseByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReleaseByIdCommandHandler(IUnitOfWork unitOfWork)
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
