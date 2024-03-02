using DarbaUzdevumaProjekts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using DarbaUzdevumaProjekts.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddCors(options => {
    options.AddPolicy("MyAllowSpecificOrigins", builder => {
        builder.AllowAnyMethod()
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyOrigin();
      
    
    
    });


});

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");
var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";

builder.Services.AddDbContext<DataContext>(options =>
{
    while (true) {
        try {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            break; 
        }
        catch (Exception ex) { Console.WriteLine("Waiting for database..."); }
        
    }
    
});




//var webHost = new WebHostBuilder()
//    .UseStartup
//    .UseContentRoot(Directory.GetCurrentDirectory())
//    .Build();






var app = builder.Build();
var scope = app.Services.CreateScope(); 

using (DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>())
{
    context.Database.Migrate();
    await Seed.SeedData(context); 
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization(); 

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback"); 

app.Run();
