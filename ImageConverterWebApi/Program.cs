using System.Net;
using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using ImageConverterWebApi.Services.DB;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

try
{
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

    //app.UseHttpsRedirection();
    app.UseDeveloperExceptionPage();
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
    //if (!app.Environment.IsDevelopment())
    //{
    //    app.Urls.Add("http://*:7777");
    //}
    app.Run();
}
catch (Exception e)
{

    var message = new string[] { e.Message, e?.StackTrace, e?.InnerException?.Message };
    var mailMessage = new MimeMessage();
    mailMessage.From.Add(new MailboxAddress("from name", "d.sadykov@inbox.ru"));
    mailMessage.To.Add(new MailboxAddress("to name", "d.sadykov@inbox.ru"));
    mailMessage.Subject = "subject";
    mailMessage.Body = new TextPart("plain")
    {
        Text = string.Join('\n', message)
    };
    using (var smtpClient = new SmtpClient())
    {
        smtpClient.Connect("smtp.mail.ru", 465, true);
        smtpClient.Authenticate("d.sadykov@inbox.ru", "CittJTRitVs1DtX394kP");
        smtpClient.Send(mailMessage);
        smtpClient.Disconnect(true);
    }
    throw;
}
static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddCors();
    services.AddControllers();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<UsersDBContext>(options => options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(10, 5, 10))));
    services.Configure<ConfigurationModel>(configuration.GetSection("MyConfiguration"));
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<IUserService, UserService>();
    services.AddTransient<LoggingMiddleware>();
    services.AddTransient<JwtMiddleware>();
    services.AddTransient<IImageConverter, ImageConverter>();
    services.AddTransient<ImageConverterService, ImageConverterService>();
}