using ImageConverterWebApi.Controllers;
using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;

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
app.UseAuthorization();
app.MapControllers();
//app.UseMiddleware<MiddlewareTest>();
app.Urls.Add("http://*:7777");

app.Run();

static void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager)
{
    services.AddControllers();
    services.Configure<ConfigurationModel>(configurationManager.GetSection("MyConfiguration"));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<MiddlewareTest>();
    services.AddTransient<IImageConverter, ImageConverter>();
    services.AddTransient<ImageConverterService, ImageConverterService>();
    services.AddCors();
}