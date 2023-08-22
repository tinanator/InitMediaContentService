using FluentValidation;
using InitMediaContentService.Application.DTOs;

namespace InitMediaContentService.Application.Validators
{
    public class ArtistValidator : AbstractValidator<ArtistDto> 
    {
        public ArtistValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
