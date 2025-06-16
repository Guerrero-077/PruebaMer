using Business.Custom;
using Business.Implements;
using Business.Iterfaces.Base;
using Business.Iterfaces.IJWT;
using Business.Iterfaces.Implements;
using Business.Repository;
using Data.Base;
using Data.Implements;
using Data.Interfaces.Base;
using Data.Interfaces.Implements;
using Entity.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPICitas.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


//Agregar Data
builder.Services.AddScoped<IUserData, UserData>();


builder.Services.AddScoped(typeof(IData<>), typeof(BaseModelData<>));
builder.Services.AddScoped<ICitasData, CitaData>();


//Agregar servicios 
builder.Services.AddScoped<IPacienteBusiness, PacienteBusiness>(); 
builder.Services.AddScoped<IDoctorBusiness, DoctorBusiness>(); 
builder.Services.AddScoped<ICitaBusiness, CitaBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped<IToken, TokenBusiness>();
builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
    };
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresa tu token JWT como: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });


});

var allowedOrigins = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
