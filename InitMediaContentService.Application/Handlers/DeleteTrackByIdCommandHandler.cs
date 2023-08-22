using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.Exceptions;
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
            var isDeleted = await _unitOfWork.ArtistRepository.DeleteAsync(request.id, cancellationToken);
            
            if (!isDeleted)
            {
                throw new ArtistNotFoundException($"Artist with id = {request.id} is not found");
            }

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
