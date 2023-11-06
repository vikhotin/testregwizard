using Regwizard.Models;

namespace Regwizard.TestData;

public class TestData
{
    public static City City1 = new()
    {
        Id = 1,
        Name = "Macondo" 
    };
    public static City City2 = new()
    {
        Id = 2,
        Name = "Ravenholm"
    };
    public static List<City> Cities = new() { City1, City2 };

    public static Province Province1 = new()
    {
        Id = 1,
        Name = "Province 1",
        CityId = City1.Id,
        City = City1
    };
    public static Province Province2 = new()
    {
        Id = 2,
        Name = "Province 2",
        CityId = City1.Id,
        City = City1
    };
    public static Province Province3 = new()
    {
        Id = 3,
        Name = "Province 3",
        CityId = City1.Id,
        City = City1
    };
    public static Province Province4 = new()
    {
        Id = 4,
        Name = "Province 4",
        CityId = City2.Id,
        City = City2
    };
    public static Province Province5 = new()
    {
        Id = 5,
        Name = "Province 5",
        CityId = City2.Id,
        City = City2
    };
    public static readonly List<Province> Provinces = new() { Province1,  Province2, Province3, Province4, Province5 };
}
