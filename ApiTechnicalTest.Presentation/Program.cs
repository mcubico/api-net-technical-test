using ApiTechnicalTest.Data.Context;
using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using ApiTechnicalTest.Domain.Repositories;
using ApiTechnicalTest.Presentation.Helpers.Filters;
using ApiTechnicalTest.Presentation.ModelsDTO;
using ArandaTechnicalTest.Domain.Repositories;
using ArandaTechnicalTest.Presentation.ModelsDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

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

builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsghts:ConnectionString"]);

builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(ExceptionFilterHelper));
});

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
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

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer( options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"])),
            ClockSkew = TimeSpan.Zero
        }
    );

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSwaggerGen(config =>
    {
        // Configuro la documentacón de swagger
        config.SwaggerDoc("v1", info: new OpenApiInfo
        {
            Version = "v1.0.0",
            Title = "Intcomex - ApiTechnicalTest",
            Description = "Prueba técnica de la empresa Intcomex para los desarrolladores de software",
            License = new OpenApiLicense { Name = "MIT" },
            Contact = new OpenApiContact { Name = "Mauricio Montoya Medrano", Email = "mcubico33@gmail.com" }
        });

        // Configuro la autenticación que debe usar swagger cuando sea requerida
        config.AddSecurityDefinition(
            name: "Bearer",
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            }
        );

        config.AddSecurityRequirement(
            new OpenApiSecurityRequirement
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
                    new string[]{ }
                }
            }    
        );

        // Configuro swagger para que exponga la documentación de los endpoints tomandola de los mismos métodos
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        config.IncludeXmlComments(xmlPath);
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();   
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("v1/swagger.json", "Intcomex Technical Test v1");
    });
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
