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
app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.Urls.Add("http://*:7777");

app.Run();

static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddCors();
    services.AddControllers();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<UsersDBContext>(options => options.UseSqlite(connectionString));
    services.Configure<ConfigurationModel>(configuration.GetSection("MyConfiguration"));
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<IUserService, UserService>();
    services.AddTransient<LoggingMiddleware>();
    services.AddTransient<JwtMiddleware>();
    services.AddTransient<IImageConverter, ImageConverter>();
    services.AddTransient<ImageConverterService, ImageConverterService>();
}