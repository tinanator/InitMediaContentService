using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Database;

namespace InitMediaContentService.Infrastructure.Persistence.Database
{ 
    public class UnitOfWork
    {
        private MediaContext _mediaContext;
        private IRepository<Artist> _artistRepository;
        private IRepository<Release> _releaseRepository;
        private IRepository<Track> _trackRepository;

        public UnitOfWork(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }

        public IRepository<Artist> ArtistRepository
        {
            get
            {
                if (_artistRepository == null)
                {
                    _artistRepository = new Repository<Artist>(_mediaContext);
                }
                return _artistRepository;
            }
        }

        public IRepository<Release> ReleaseRepository
        {
            get
            {
                if (_releaseRepository == null)
                {
                    _releaseRepository = new Repository<Release>(_mediaContext);
                }
                return _releaseRepository;
            }
        }

        public IRepository<Track> TrackRepository
        {
            get
            {
                if (_trackRepository == null)
                {
                    _trackRepository = new Repository<Track>(_mediaContext);
                }
                return _trackRepository;
            }
        }
    }
}
