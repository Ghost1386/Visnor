﻿using Microsoft.AspNetCore.Mvc;

namespace Visnor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult HomePage()
    {
        return View();
    }
}