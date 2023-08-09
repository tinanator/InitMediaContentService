using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private MediaContext _mediaContext;
        public IRepository<Artist> ArtistRepository { get; }
        public IRepository<Release> ReleaseRepository { get; }
        public IRepository<Track> TrackRepository { get; }

        public UnitOfWork(MediaContext mediaContext,
            IRepository<Artist> artistRepository,
            IRepository<Release> releaseRepository,
            IRepository<Track> trackRepository)
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
