using ApiTechnicalTest.Data.Context;
using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using ApiTechnicalTest.Domain.Repositories;
using ApiTechnicalTest.Presentation.ModelsDTO;
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

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("localdb"))
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

builder.Services.AddAutoMapper(
    configAction =>
    {
        // Product AutoMapper
        configAction.CreateMap<ProductEntity, ProductDTO>();
        configAction.CreateMap<ProductDTO, ProductEntity > ();
        configAction.CreateMap<ProductCreationDTO, ProductEntity > ();

        // Category AutoMapper
        configAction.CreateMap<CategoryEntity, CategoryDTO>();
        configAction.CreateMap<CategoryDTO, CategoryEntity>();
        configAction.CreateMap<CategoryCreationDTO, CategoryEntity>();
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

//migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dataContext.Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseCors(ALLOWED_ORIGINS);

app.UseStaticFiles();

app.MapControllers();

app.Run();
