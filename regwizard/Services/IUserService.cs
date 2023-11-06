using Regwizard.Models;

namespace Regwizard.Services;

public interface IUserService
{
    Task SaveUserAsync(SaveUserRequest user);
}