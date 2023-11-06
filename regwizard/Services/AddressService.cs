using Microsoft.EntityFrameworkCore;
using Regwizard.Db;
using Regwizard.Models;

namespace Regwizard.Services
{
    public class AddressService : IAddressService
    {
        private readonly Context context;

        public AddressService(Context context)
        {
            this.context = context;
        }

        public Task<List<CityDto>> GetCities()
        {
            return context.City.Select(c => new CityDto() { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        public Task<List<ProvinceDto>> GetProvinces(int cityId)
        {
            return context.Province.Where(p => p.CityId == cityId)
                .Select(c => new ProvinceDto() { Id = c.Id, Name= c.Name }).ToListAsync();
        }
    }
}