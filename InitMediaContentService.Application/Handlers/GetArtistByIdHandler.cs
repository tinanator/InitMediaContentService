using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Domain.Entities;
using MediatR;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Infrastructure.Persistence.Database;

namespace InitMediaContentService.Application.Handlers
{
    public class GetArtistByIdHandler : IRequestHandler<GetArtistByIdQuery, Artist>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetArtistByIdHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Artist> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ArtistRepository.FindByIdAsync(request.id, cancellationToken);
        }
    }
}
