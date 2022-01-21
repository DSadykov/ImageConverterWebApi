using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using ImageConverterWebApi.Services.DB;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services, builder.Configuration);

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<LoggingMiddleware>();

app.Urls.Add("http://*:7777");

app.Run();

static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddControllers();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<UsersDBContext>(options => options.UseSqlite(connectionString));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.Configure<ConfigurationModel>(configuration.GetSection("MyConfiguration"));
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<LoggingMiddleware>();
    services.AddTransient<IImageConverter, ImageConverter>();
    services.AddTransient<ImageConverterService, ImageConverterService>();
    services.AddCors();
}