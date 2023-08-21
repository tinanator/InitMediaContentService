using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitMediaContentService.Application.DTOs
{
    public record ArtistDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
