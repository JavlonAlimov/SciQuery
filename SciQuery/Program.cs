using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SciQuery.Domain.User;
using SciQuery.Domain.User.AppRoles;
using SciQuery.Infrastructure.Persistance.DbContext;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Identity Usermanager and rolemanager
builder.Services.AddDbContext<SciQueryDbContext>();
builder.Services.AddIdentityCore<IdentityUser>()
 .AddEntityFrameworkStores<SciQueryDbContext>()
 .AddDefaultTokenProviders();
//AddAuthentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        var secret = builder.Configuration["JwtConfig:SecretKey"];
        var issuer = builder.Configuration["JwtConfig:ValidIssuer"];
        var audience = builder.Configuration["JwtConfig:ValidAudiences"];
        if (secret is null ||  issuer is null || audience is null)
        {
            throw new ApplicationException("Jwt is not set in the Configuration");
        }
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
        };
    });

//Strongly password policy and Security DDOS
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
    // User settings
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;

    //Blocking fails

    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
});

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Jwt authorization header using the Bearer scheme. Example :\"Authorization : Bearer {token}\"",
        Name = "Authoriation",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            }
            ,new string[]{}
        }
    });

});
//Policies for Role requirements 

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminstratorRole", policy => policy.RequireRole(AppRoles.Administrator));
options.AddPolicy("RequireUserRole", policy => policy.RequireRole(AppRoles.User));
options.AddPolicy("RequireMasterRole", policy => policy.RequireRole(AppRoles.Master));

// Master is user .
options.AddPolicy("RequireUserAndMasterRole", policy => policy.RequireRole(AppRoles.Administrator, AppRoles.User));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


// Check if the roles exist, if not, create them
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    // Ensure the database is created.
    var dbContext = services.GetRequiredService<SciQueryDbContext>();
    dbContext.Database.EnsureCreated();

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync(AppRoles.User))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.User));
    }

    if (!await roleManager.RoleExistsAsync(AppRoles.Administrator))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.Administrator));
    }

    if (!await roleManager.RoleExistsAsync(AppRoles.Master))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.Master));
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
