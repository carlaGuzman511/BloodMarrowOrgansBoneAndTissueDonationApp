using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class DonationCenterValidator : AbstractValidator<DonationCenterRequest>
    {
        public DonationCenterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre del centro medico es requerido");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("La ubicacion del centro medico es requerido");

            RuleFor(x => x.DonationTypes)
                .NotEmpty()
                .WithMessage("Los tipos de donacion que realiza el centro medico es requerido");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("La imagen del centro medico es requerido");
        }
    }
}
