using FluentValidation;
using InitMediaContentService.Application.DTOs;

namespace InitMediaContentService.Application.Validators
{
    public class ReleaseValidator : AbstractValidator<ReleaseDto> 
    {
        public ReleaseValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
