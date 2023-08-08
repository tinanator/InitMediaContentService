using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Database;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{ 
    public class UnitOfWork
    {
        private MediaContext _mediaContext;
        public Repository<Artist> ArtistRepository { get; }
        public Repository<Release> ReleaseRepository { get; }
        public Repository<Track> TrackRepository { get; }

        public UnitOfWork(MediaContext mediaContext,
            Repository<Artist> artistRepository,
            Repository<Release> releaseRepository,
            Repository<Track> trackRepository)
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
