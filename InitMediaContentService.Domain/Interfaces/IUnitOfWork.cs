using InitMediaContentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitMediaContentService.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Artist, long> ArtistRepository { get; }
        public IRepository<Release, long> ReleaseRepository { get; }
        public IRepository<Track, long> TrackRepository { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
