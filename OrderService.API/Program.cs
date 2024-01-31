using Microsoft.EntityFrameworkCore;
using OrderService.API;
using OrderService.API.Filters;
using OrderService.Application;
using OrderServise.Infrastructure;
using OrderServise.Infrastructure.Persistance;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(optiopn =>
{
    optiopn.Filters.Add(typeof(GlobalExeptionFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
 builder.Services.AddInfrastructurService(builder.Configuration);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrderDbContext>();
    //await context.Database.MigrateAsync();
    await context.Database.MigrateAsync();
   await SeedData.SeedDataLast(context);
   ;
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   // SeedData.SeedAppData(app);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
