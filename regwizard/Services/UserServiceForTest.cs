using FluentValidation;
using FluentValidation.Results;
using Regwizard.Db;
using Regwizard.Models;
using Regwizard.TestData;

namespace Regwizard.Services;

public class UserServiceForTest : IUserService
{
    private readonly List<SaveUserRequest> requests = new();

    public async Task SaveUserAsync(SaveUserRequest user)
    {
        if (user.ProvinceId < TestData.TestData.Province1.Id || user.ProvinceId > TestData.TestData.Province5.Id)
            throw new ValidationException(new List<ValidationFailure> { new ValidationFailure(
                propertyName: nameof(user.ProvinceId), errorMessage: "Province Id doesn't exist", attemptedValue: user.ProvinceId)});

        requests.Add(user);
    }
}