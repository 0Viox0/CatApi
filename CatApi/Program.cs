using Asp.Versioning;
using Bll.Extensions;
using CatApi.Extensions;
using CatApi.Filters;
using Dal.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => 
    options.Filters.Add<CustomExceptionFilter>())
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddBllServices();
builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();