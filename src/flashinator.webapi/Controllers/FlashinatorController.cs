using Microsoft.AspNetCore.Mvc;
using flashinator.core;
using flashinator.data;

namespace flashinator.webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashinatorController : ControllerBase
{
    private readonly FlashinatorDataProvider _flashinatorDataProvider;

    private readonly ILogger<FlashinatorController> _logger;

    public FlashinatorController(
        ILogger<FlashinatorController> logger,
        FlashinatorDataProvider flashinatorDataProvider)
    {
        _logger = logger;
        _flashinatorDataProvider = flashinatorDataProvider;
    }

    [HttpGet(Name = "GetFlashinators")]
    public IEnumerable<Flashinator> Get()
    {
        return _flashinatorDataProvider.GetFlashinators();
    }

    [HttpGet("random")]
    public Flashinator GetRandom()
    {
        return _flashinatorDataProvider.RandomFlashinator();
    }
}
