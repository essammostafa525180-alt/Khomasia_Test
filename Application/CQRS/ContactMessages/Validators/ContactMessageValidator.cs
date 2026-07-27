using Application.CQRS.ContactMessages.Commands;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.ContactMessages.Validators
{

    public class CreateContactMessageCommandValidator
        : AbstractValidator<CreateContactMessageCommand>
    {
        public CreateContactMessageCommandValidator(
            IStringLocalizer<Resources.Resources.Shared> localizer)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer["NameRequired"]);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(localizer["EmailRequired"])
                .EmailAddress()
                .WithMessage(localizer["EmailInvalid"]);

            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage(localizer["SubjectRequired"]);

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(localizer["MessageRequired"]);
        }
    }
}