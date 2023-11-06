using Microsoft.EntityFrameworkCore;
using Regwizard.Models;

namespace Regwizard.Services
{
    public class AddressServiceForTest : IAddressService
    {
        public Task<List<CityDto>> GetCities()
        {
            return Task.FromResult(TestData.TestData.Cities.Select(c => new CityDto() { Id = c.Id, Name = c.Name }).ToList());
        }

        public Task<List<ProvinceDto>> GetProvinces(int cityId)
        {
            return Task.FromResult(TestData.TestData.Provinces.Where(p => p.CityId == cityId).Select(c => new ProvinceDto() { Id = c.Id, Name = c.Name }).ToList());
        }
    }
}