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