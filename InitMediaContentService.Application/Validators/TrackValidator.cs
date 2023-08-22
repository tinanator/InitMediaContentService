using FluentValidation;
using InitMediaContentService.Application.DTOs;

namespace InitMediaContentService.Application.Validators
{
    public class TrackValidator : AbstractValidator<TrackDto>
    {
        public TrackValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
