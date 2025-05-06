
using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class DonationTypeValidatorTest: AbstractValidator<DonationTypeRequest>
    {
        public DonationTypeValidatorTest()
        {
            RuleFor(x => x.Name)
                .NotEmpty().
                WithMessage("El nombre del tipo de donacion es requerido");

            RuleFor(x => x.Requirements)
                .NotEmpty()
                .WithMessage("Los requerimientos del tipo de donacion es requerido");

            RuleFor(x => x.Importance)
                .NotEmpty()
                .WithMessage("La importancia del tipo de donacion es requerido");

            RuleFor(x => x.Benefits)
                .NotEmpty()
                .WithMessage("Los beneficios del tipo de donacion es requerido");

            RuleFor(x => x.SecondaryEffects)
                .NotEmpty()
                .WithMessage("Los efectos secundarios del tipo de donacion es requerido");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripcion del tipo de donacion es requerido");

            RuleFor(x => x.Process)
                .NotEmpty()
                .WithMessage("El proceso del tipo de donacion es requerido");
        }
    }
}
