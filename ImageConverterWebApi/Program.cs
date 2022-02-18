using System.Net;
using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using ImageConverterWebApi.Services.DB;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;


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
else
{
    app.UseExceptionHandler("/Error");
}
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
app.UseHttpLogging();
#if DEBUG
app.Urls.Add("http://*:7777");
#endif
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.Run();


static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddCors();
    services.AddControllers();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<UsersDBContext>(options => options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(10, 5, 10))));
    services.Configure<ConfigurationModel>(configuration.GetSection("MyConfiguration"));
    services.AddHttpsRedirection(options => options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect);
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<IUserService, UserService>();
    services.AddTransient<LoggingMiddleware>();
    services.AddTransient<JwtMiddleware>();
    services.AddTransient<IImageConverter, ImageConverter>();
    services.AddTransient<ImageConverterService, ImageConverterService>();
}