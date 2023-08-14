using InitMediaContentService.Application.Commands;
using InitMediaContentService.Domain.Interfaces;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class DeleteArtistByIdCommandHandler : IRequestHandler<DeleteArtistByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteArtistByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteArtistByIdCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ArtistRepository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
