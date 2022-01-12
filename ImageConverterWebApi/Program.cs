using ImageConverterWebApi.Services;
using ImageConverterWebApi.Services.NameConverter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IImageConverter, ImageConverter>();
builder.Services.AddTransient<INameConverter, NameConverter>();
builder.Services.AddSingleton<ImageConverterService, ImageConverterService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Urls.Add("http://*:7777");

app.Run();
