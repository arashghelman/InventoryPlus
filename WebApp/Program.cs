using System.Text.Json.Serialization;
using Dapper;
using WebApp.Utilities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
builder.Services.AddControllers();
builder.Services.AddRepositories();

SqlMapper.AddTypeHandler(new SqliteGuidTypeHandler());

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();