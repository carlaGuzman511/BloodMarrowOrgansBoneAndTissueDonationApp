using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class BloodTypeRequestValidator : AbstractValidator<BloodTypeRequest>
    {
        public BloodTypeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Tipo de Sangre es requerido");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("La Imagen del Tipo de Sangre es requerido");
        }
    }
}
