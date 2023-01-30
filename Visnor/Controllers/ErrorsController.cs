using Microsoft.AspNetCore.Mvc;

namespace Visnor.Controllers;

public class ErrorsController : Controller
{
    private readonly ILogger<ErrorsController> _logger;

    public ErrorsController(ILogger<ErrorsController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult ErrorsPage(int statusCode, string message)
    {
        return View();
    }
}