using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace InitMediaContentService.Application.Mappers
{
    [Mapper]
    public partial class ReleaseMapper
    {
        public partial ReleaseDto ReleaseToReleaseDto(Release release);

        public partial Release ReleaseDtoToRelease(ReleaseDto releaseDto);
    }
}
