using ERPSystem.API.Middleware;
using ERPSystem.Business.Abstract;
using ERPSystem.Business.Concrete;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.DataAccess.Concrete.Context;
using ERPSystem.DataAccess.Concrete.DataManagement;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
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

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ERPContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ErpDb"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<ICompanyService,CompanyManager>();
builder.Services.AddScoped<IDepartmentService,DepartmentManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IInvoiceService,InvoiceManager>();
builder.Services.AddScoped<IInvoiceDetailService,InvoiceDetailManager>();
builder.Services.AddScoped<IOfferService,OfferManager>();
builder.Services.AddScoped<IProcessTypeService,ProcessTypeManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IRequestService,RequestManager>();
builder.Services.AddScoped<IRoleService,RoleManager>();
builder.Services.AddScoped<IStatusService,StatusManager>();
builder.Services.AddScoped<IStockService,StockManager>();
builder.Services.AddScoped<IStockDetailService,StockDetailManager>();
builder.Services.AddScoped<IUnitService,UnitManager>();
builder.Services.AddScoped<IUserService,UserManager>();
builder.Services.AddScoped<IUserRoleService,UserRoleManager>();



builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"], // Tokeni oluşturan tarafin adresi
        ValidAudience = builder.Configuration["JWT:Audiance"], // Tokenin kullanilacagi hedef adres
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Token"]))// Gizli anahtar
    };
});
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseGlobalExceptionMiddleware();
app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
