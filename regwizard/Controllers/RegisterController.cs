using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Regwizard.Models;
using Regwizard.Services;
using System.Net;

namespace Regwizard.Controllers;

[ApiController]
[Route("user")]
public class RegisterController : Controller
{
    private readonly IUserService userService;

    public RegisterController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> SaveUser(SaveUserRequest request, IValidator<SaveUserRequest> validator)
    {
        validator.ValidateAndThrow(request);
        await userService.SaveUserAsync(request);
        return StatusCode((int)HttpStatusCode.Created);
    }
}