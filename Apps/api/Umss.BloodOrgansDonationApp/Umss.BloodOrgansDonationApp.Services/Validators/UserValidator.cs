using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Validators
{
    internal class UserValidator: AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El email del usuario es requerido");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("La direccion del usuario es requerido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("El password del usuario es requerido");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("La fecha de nacimiento del usuario es requerido");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("El numero de telefono del usuario es requerido");

            RuleFor(x => x.BloodTypeId)
                .NotEmpty()
                .WithMessage("El id del tipo de sangre del usuario es requerido");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("El nombre completo del usuario es requerido");       

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("La imagen del usuario es requerida");
        }
    }
}
