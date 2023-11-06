using FluentValidation;
using Regwizard.Models;

namespace Regwizard.Validation
{
    public class SaveUserRequestValidator : AbstractValidator<SaveUserRequest>
    {
        public SaveUserRequestValidator()
        {
            RuleFor(r => r.Login).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty().Must(BeAValidPassword);
            RuleFor(r => r.ConfirmPassword).Equal(r => r.Password);
            RuleFor(r => r.ProvinceId).NotEmpty();
        }

        private bool BeAValidPassword(string? arg)
        {
            if (string.IsNullOrWhiteSpace(arg))
                return false;
            return arg.Any(char.IsDigit) && arg.Any(char.IsLetter);
        }
    }
}
