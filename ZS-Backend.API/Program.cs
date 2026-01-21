using Microsoft.EntityFrameworkCore;
using ZS_Backend.API.Data;
using ZS_Backend.API.Mappings;
using ZS_Backend.API.Repositories;
using ZS_Backend.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ZsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZSDBConnectionString")));

builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfiles));

builder.Services.AddScoped<IClientRepository, SqlClientRepository>();
builder.Services.AddScoped<IClientService, SqlClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
