using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class CommentRequestValidator : AbstractValidator<CommentRequest>
    {
        public CommentRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripcion es requerida");
        }
    }
}
