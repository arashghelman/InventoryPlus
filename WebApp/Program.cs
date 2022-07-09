using System.Text.Json.Serialization;
using Auth0.AspNetCore.Authentication;
using Dapper;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using WebApp.Utilities;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddMvc().AddJsonOptions(options =>
{
    var enumConverter = new JsonStringEnumConverter();
    options.JsonSerializerOptions.Converters.Add(enumConverter);
});

services.AddControllers();
services.AddControllersWithViews();

services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = configuration["Auth0:Domain"];
    options.ClientId = configuration["Auth0:ClientId"];
    options.ClientSecret = configuration["Auth0:ClientSecret"];

    options.OpenIdConnectEvents = new OpenIdConnectEvents
    {
        OnRemoteFailure = context =>
        {
            context.Response.Redirect("/");
            context.HandleResponse();

            return Task.FromResult(0);
        }
    };
});

services.AddRepositories();

SqlMapper.AddTypeHandler(new SqliteGuidTypeHandler());

var app = builder.Build();
app.UseRouting();
app.UseCors();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();