using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Regwizard.Validation;
using Regwizard.Db;
using Regwizard.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

if (args.Length > 0 && args[0] == "--testWithActualDatabase")
{
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IAddressService, AddressService>();
    builder.Services.AddDbContext<Context>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Context")));
}
else
{
    builder.Services.AddSingleton<IUserService, UserServiceForTest>();
    builder.Services.AddSingleton<IAddressService, AddressServiceForTest>();
}

builder.Services.AddProblemDetails(c =>
{
    c.CustomizeProblemDetails = context =>
    {
        var exceptionHandlerFeature = context.HttpContext.Features.Get<IExceptionHandlerFeature>();
        var ex = exceptionHandlerFeature?.Error;

        if (ex is ValidationException valEx)
        {
            var dict = valEx.Errors.GroupBy(vf => vf.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(i => i.ErrorMessage));

            context.HttpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

            context.ProblemDetails.Type = "https://tools.ietf.org/html/rfc4918#section-11.2";
            context.ProblemDetails.Title = "One or more validation errors occured";
            context.ProblemDetails.Detail = "See details in `errors` section";
            context.ProblemDetails.Extensions.Add("errors", dict);
            context.ProblemDetails.Status = StatusCodes.Status422UnprocessableEntity;

            return;
        }
    };
});

// validation
builder.Services.AddValidatorsFromAssemblyContaining<SaveUserRequestValidator>();

var app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();

app.Run();

public partial class Program { }