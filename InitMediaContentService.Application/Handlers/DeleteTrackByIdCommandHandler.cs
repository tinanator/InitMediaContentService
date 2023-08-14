using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class DeleteTrackByIdCommandHandler : IRequestHandler<DeleteTrackByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTrackByIdCommandHandler(IUnitOfWork unitOfWork)
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
