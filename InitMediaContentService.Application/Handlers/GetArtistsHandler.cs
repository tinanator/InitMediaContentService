using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Infrastructure.Persistence.Database;
using MediatR;

namespace InitMediaContentService.Application.Handlers
{
    public class GetArtistsHandler : IRequestHandler<GetArtistsQuery, IEnumerable<Artist>>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetArtistsHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Artist>> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ArtistRepository.GetAllAsync(cancellationToken);
        }
    }
}
