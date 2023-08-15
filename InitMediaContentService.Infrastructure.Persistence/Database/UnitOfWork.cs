using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private MediaContext _mediaContext;
        public IRepository<Artist, Guid> ArtistRepository { get; }
        public IRepository<Release, Guid> ReleaseRepository { get; }
        public IRepository<Track, Guid> TrackRepository { get; }

        public UnitOfWork(MediaContext mediaContext,
            IRepository<Artist, Guid> artistRepository,
            IRepository<Release, Guid> releaseRepository,
            IRepository<Track, Guid> trackRepository)
        {
            _mediaContext = mediaContext;
            ArtistRepository = artistRepository;
            ReleaseRepository = releaseRepository;
            TrackRepository = trackRepository;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _mediaContext.SaveChangesAsync(cancellationToken);
        }
    }
}
