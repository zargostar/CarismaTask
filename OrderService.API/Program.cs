using Identity.Bugeto.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderService.API;
using OrderService.API.Filters;
using OrderService.Application;
using OrderService.Application.Contracts;
using OrderServise.Domain.Common;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure;
using OrderServise.Infrastructure.Persistance;
using Serilog;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddControllers(optiopn =>
{
    optiopn.Filters.Add(typeof(GlobalExeptionFilter));
    optiopn.Filters.Add(typeof(BadRequestFilter));
}).ConfigureApiBehaviorOptions(BadRequestBehavior.Parse);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
            "Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
           new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddAuthorization(config =>
{
    //user should have both claim to be authorized
    // config.AddPolicy("IsAdmin", policy => policy.RequireClaim("userRole", "admin"));
    // config.AddPolicy("IsCustomer", policy => policy.RequireClaim("customerRole", "customer"));
    config.AddPolicy("IsOperator", policy => policy.RequireRole(UserRole.OPERATOR));
});
builder.Services.AddScoped<ICurrentUser>(provider =>
{
    var context = provider.GetService<IHttpContextAccessor>();
    var currentUser = new CurrentUser()
    {
        FullName= context?.HttpContext?.User.FindFirstValue("fullName") ?? "0",
        UserId= context?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0",
    };
    return currentUser;
});

builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructurService(builder.Configuration);
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DataBaseContext>()
    .AddErrorDescriber<CustomIdentityError>();
builder.Services.Configure<IdentityOptions>(options =>
{
   // options.User.AllowedUserNameCharacters = "0123";
   options.User.RequireUniqueEmail = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric=false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(1);
    options.SignIn.RequireConfirmedEmail = false;

});
builder.Services.AddAuthentication(u =>
{
    u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecurityKey"])),
        ClockSkew = TimeSpan.Zero

    };
});
;
builder.Services.AddCors(option => {
    string front =builder.Configuration["FrontEnd"].ToString();
    option.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(front).AllowAnyHeader().
        AllowAnyMethod()
        .WithExposedHeaders(new string[] { "rowcount" });
    });

});
builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddInfrastructurService(builder.Configuration);
builder.Services.AddHangfire(configuration => configuration
       //.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
       .UseSimpleAssemblyNameTypeSerializer()
       .UseRecommendedSerializerSettings()
       .UseSqlServerStorage(builder.Configuration["HangFireDb"], new SqlServerStorageOptions
       {
           CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
           SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
           QueuePollInterval = TimeSpan.Zero,
           UseRecommendedIsolationLevel = true,
           DisableGlobalLocks = true
       }));
builder.Services.AddHangfireServer();
        
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataBaseContext>();
    //await context.Database.MigrateAsync();
    await context.Database.MigrateAsync();
   await SeedData.SeedDataLast(context);
   await SeedData.SeedUserAppData(app)
   ;
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   // SeedData.SeedAppData(app);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.UseHangfireDashboard();
app.Run();
