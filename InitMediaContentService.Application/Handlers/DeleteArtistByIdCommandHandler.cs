using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.Exceptions;
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
            var isDeleted = await _unitOfWork.ArtistRepository.DeleteAsync(request.id, cancellationToken);

            if (!isDeleted) 
            {
                throw new ArtistNotFoundException($"Artist with id = {request.id} is not found");
            }

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
