using ArandaTechnicalTest.Data.Context;
using ArandaTechnicalTest.Data.Entities;
using ArandaTechnicalTest.Domain.Interfaces.Repositories;
using ArandaTechnicalTest.Domain.Repositories;
using ArandaTechnicalTest.Presentation.ModelsDTO;
using Microsoft.EntityFrameworkCore;

const string ALLOWED_ORIGINS = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ALLOWED_ORIGINS, 
        policy => 
        { 
            policy.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader(); 
        });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("localdb")
));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(
    configAction =>
    {
        configAction.CreateMap<Products, ProductDTO>();
        configAction.CreateMap<ProductDTO, Products > ();
        configAction.CreateMap<ProductCreationDTO, Products > ();
    },
    typeof(Program).Assembly
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ALLOWED_ORIGINS);

//app.UseAuthorization();

app.MapControllers();

app.Run();
