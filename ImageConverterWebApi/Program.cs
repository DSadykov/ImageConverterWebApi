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

app.Urls.Add("http://*:7777");

app.Run();

static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.Configure<ConfigurationModel>(configuration.GetSection("MyConfiguration"));
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<IImageConverter, ImageConverter>();
    services.AddTransient<ImageConverterService, ImageConverterService>();
    services.AddCors();
}