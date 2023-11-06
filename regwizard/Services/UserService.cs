using FluentValidation;
using FluentValidation.Results;
using Regwizard.Db;
using Regwizard.Models;

namespace Regwizard.Services;

public class UserService : IUserService
{
    private readonly Context context;

    public UserService(Context context)
    {
        this.context = context;
    }

    public async Task SaveUserAsync(SaveUserRequest user)
    {
        if (await context.Province.FindAsync(user.ProvinceId) == null)
            throw new ValidationException(new List<ValidationFailure> { new ValidationFailure(
                propertyName: nameof(user.ProvinceId), errorMessage: "Province Id doesn't exist", attemptedValue: user.ProvinceId)});

        var dbUser = new User()
        {
            Login = user.Login!,
            Password = user.Password!,
            IsAgree = user.IsAgree,
            ProvinceId = user.ProvinceId,
        };
        context.User.Add(dbUser);
        await context.SaveChangesAsync();
    }
}