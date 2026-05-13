using Microsoft.EntityFrameworkCore;
using SistemaAlmacen.Data;
using SistemaAlmacen.Mapper;
using SistemaAlmacen.Repository;
using SistemaAlmacen.Repository.Interfaces;
using SistemaAlmacen.Services;
using SistemaAlmacen.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//para swager
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//para configurar la base de adtos y obtener la acadena de connexión
builder.Services.AddDbContext<AppDbContext>(entity =>
{
    entity.UseSqlServer(builder.Configuration.GetConnectionString("Connexion"));
});

//mapper
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<MapperProfile>();
});




//para repository
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

//service
builder.Services.AddScoped<IProductoService,ProductoService>();














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
