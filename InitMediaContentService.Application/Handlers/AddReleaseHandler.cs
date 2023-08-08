using InitMediaContentService.Application.Commands;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class AddReleaseHandler : IRequestHandler<AddReleaseCommand>
    {
        private readonly UnitOfWork _unitOfWork;
        public AddReleaseHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddReleaseCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ReleaseRepository.InsertAsync(request.release);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
