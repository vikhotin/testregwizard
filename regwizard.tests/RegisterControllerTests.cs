using Regwizard.Models;
using System.Net;
using System.Net.Http.Json;

namespace Regwizard.Tests;

public class RegisterControllerTests : IClassFixture<ApplicationFactory>
{
    private readonly ApplicationFactory factory;

    public RegisterControllerTests(ApplicationFactory factory)
    {
        this.factory = factory;
    }

    [Fact]
    public async void RegisterOk()
    {
        var request = new SaveUserRequest()
        {
            Login = "test@test.com",
            Password = "passw0rd",
            ConfirmPassword = "passw0rd",
            IsAgree = true,
            ProvinceId = 1
        };

        using var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("user", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async void RegisterBadEmail()
    {
        var request = new SaveUserRequest()
        {
            Login = "test",
            Password = "passw0rd",
            ConfirmPassword = "passw0rd",
            IsAgree = true,
            ProvinceId = 1
        };

        using var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("user", request);

        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        Assert.Contains("Login", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async void RegisterBadPassword()
    {
        var request = new SaveUserRequest()
        {
            Login = "test@test.com",
            Password = "password",
            ConfirmPassword = "password",
            IsAgree = true,
            ProvinceId = 1
        };

        using var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("user", request);

        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        Assert.Contains("Password", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async void RegisterMismatchPassword()
    {
        var request = new SaveUserRequest()
        {
            Login = "test@test.com",
            Password = "passw0rd",
            ConfirmPassword = "password",
            IsAgree = true,
            ProvinceId = 1
        };

        using var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("user", request);

        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        Assert.Contains("ConfirmPassword", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async void RegisterProvinceNotExtsts()
    {
        var request = new SaveUserRequest()
        {
            Login = "test@test.com",
            Password = "passw0rd",
            ConfirmPassword = "passw0rd",
            IsAgree = true,
            ProvinceId = 6
        };

        using var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("user", request);

        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        Assert.Contains("Province", await response.Content.ReadAsStringAsync());
    }
}
