using Regwizard.Models;
using System.Net.Http.Json;

namespace Regwizard.Tests;

public class AddressControllerTests : IClassFixture<ApplicationFactory>
{
    private readonly ApplicationFactory factory;

    public AddressControllerTests(ApplicationFactory factory)
    {
        this.factory = factory;
    }

    [Fact]
    public async void GetCitiesOk()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync("cities");

        Assert.True(response.IsSuccessStatusCode);
        var responseModel = await response.Content.ReadFromJsonAsync<List<CityDto>>();
        Assert.NotNull(responseModel);
        Assert.Equal(2, responseModel.Count);
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 2)]
    public async void GetProvincesOk(int cityId, int provCount)
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync($"cities/{cityId}/provinces");

        Assert.True(response.IsSuccessStatusCode);
        var responseModel = await response.Content.ReadFromJsonAsync<List<CityDto>>();
        Assert.NotNull(responseModel);
        Assert.Equal(provCount, responseModel.Count);
    }
}