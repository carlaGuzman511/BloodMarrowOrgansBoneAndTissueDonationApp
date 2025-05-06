using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class DonationPostValidatorTest: AbstractValidator<DonationPostRequest>
    {
        public DonationPostValidatorTest()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("El id del usuario es requerido");

            RuleFor(x => x.BloodTypeId)
                .NotEmpty()
                .WithMessage("La id del tipo de sangre es requerido");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("La imagen de la publicacion es requerido");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripcion de la publicacion es requerido");

            RuleFor(x => x.DonationTypeId)
                .NotEmpty()
                .WithMessage("El id del tipo de donacion es requerido");
        }
    }
}
