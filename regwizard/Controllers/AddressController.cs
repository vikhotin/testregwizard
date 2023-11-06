using Microsoft.AspNetCore.Mvc;
using Regwizard.Services;

namespace Regwizard.Controllers;

[ApiController]
[Route("cities")]
public class AddressController : Controller
{
    private readonly IAddressService addressService;

    public AddressController(IAddressService addressService)
    {
        this.addressService = addressService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var result = await addressService.GetCities();
        return Ok(result);
    }

    [HttpGet("{cityId}/provinces")]
    public async Task<IActionResult> GetProvinces(int cityId)
    {
        var result = await addressService.GetProvinces(cityId);
        return Ok(result);
    }
}
