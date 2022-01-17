using ImageConverterWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace ImageConverterWebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AvailableExtensionsController : ControllerBase
{
    private readonly ILogger<AvailableExtensionsController> _logger;
    private readonly IOptions<ConfigurationModel> _options;

    public AvailableExtensionsController(ILogger<AvailableExtensionsController> logger, IOptions<ConfigurationModel> options)
    {
        _logger = logger;
        _options = options;
    }
    [HttpGet(Name = "GetAvailableExtensions")]
    public List<string> Get()
    {
        List<string>? result = _options.Value.AvailableExtensions;
        _logger.LogInformation("Returned available extensions {exts}", result);
        return result;
    }
}
