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
        public IRepository<Artist, Guid> ArtistRepository { get; }
        public IRepository<Release, Guid> ReleaseRepository { get; }
        public IRepository<Track, Guid> TrackRepository { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
