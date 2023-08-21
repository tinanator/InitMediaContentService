using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private MediaContext _mediaContext;
        public IRepository<Artist, long> ArtistRepository { get; }
        public IRepository<Release, long> ReleaseRepository { get; }
        public IRepository<Track, long> TrackRepository { get; }

        public UnitOfWork(MediaContext mediaContext,
            IRepository<Artist, long> artistRepository,
            IRepository<Release, long> releaseRepository,
            IRepository<Track, long> trackRepository)
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
