using Bll.Extensions;
using CatApi.Extensions;
using Dal.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddBllServices();
builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();