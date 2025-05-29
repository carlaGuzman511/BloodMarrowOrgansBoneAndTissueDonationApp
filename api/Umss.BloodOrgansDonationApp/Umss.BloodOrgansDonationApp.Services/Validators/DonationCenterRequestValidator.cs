using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class DonationCenterRequestValidator : AbstractValidator<DonationCenterRequest>
    {
        public DonationCenterRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre del centro medico es requerido");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("La ubicacion del centro medico es requerido");

            RuleFor(x => x.Latitude)
                .NotEmpty()
                .WithMessage("La latitud del centro medico es requerido");

            RuleFor(x => x.Longitude)
                .NotEmpty()
                .WithMessage("La longitud del centro medico es requerido");

            RuleFor(x => x.DonationTypeIds)
                .NotEmpty()
                .WithMessage("Los tipos de donacion que realiza el centro medico es requerido");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("La imagen del centro medico es requerido");
        }
    }
}
