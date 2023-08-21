using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitMediaContentService.Application.DTOs
{
    public record ReleaseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ArtistId { get; set; }
    }
}
