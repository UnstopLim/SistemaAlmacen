using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using SistemaAlmacen.Data;
using SistemaAlmacen.Mapper;
using SistemaAlmacen.Repository;
using SistemaAlmacen.Repository.Interfaces;
using SistemaAlmacen.Services;
using SistemaAlmacen.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//cors 
//“Voy a configurar reglas de acceso desde otros orígenes.”
builder.Services.AddCors(options =>
{
    //agregra politicas
    options.AddPolicy("AngularPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()//Permite cualquier header HTTP.
                  .AllowAnyMethod();//Permite todos los métodos HTTP:
        });
});


//paa login 
//.Net 10 para swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TuApp API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT usando Bearer. Ejemplo: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});



//program.cs es para la verficacion del token
//---JWT Authentication-- -
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);
builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, //¿Quién creó el token?
        ValidateAudience = true,
        ValidateLifetime = true, //Verifica expiración.
        ValidateIssuerSigningKey = true, //Verifica la FIRMA DIGITAL.
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)//Le das a .NET la CLAVE SECRETA.
    };
});



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
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//service
builder.Services.AddScoped<IProductoService,ProductoService>();
builder.Services.AddScoped<IUsuarioService,UsuarioService>();













var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AngularPolicy");

app.MapControllers();

app.Run();
