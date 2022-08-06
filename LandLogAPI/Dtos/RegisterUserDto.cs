using FluentValidation;
using LandLogAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace LandLogAPI.Dtos
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(UserManager<AppUser> userManager)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = userManager.Users.FirstOrDefault((AppUser u) => u.Email == value);

                    if (emailInUse != null)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
