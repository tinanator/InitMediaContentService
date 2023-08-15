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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}
