using Regwizard.Models;

namespace Regwizard.Services
{
    public interface IAddressService
    {
        Task<List<CityDto>> GetCities();
        Task<List<ProvinceDto>> GetProvinces(int cityId);
    }
}