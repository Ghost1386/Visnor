using Microsoft.AspNetCore.Mvc;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.AuthDto;

namespace Visnor.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly ErrorsController _errorsController;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, ErrorsController errorsController, 
        IAuthService authService)
    {
        _logger = logger;
        _errorsController = errorsController;
        _authService = authService;
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginDto loginDto)
    {
        try
        {
            var authResponse = _authService.Login(loginDto);

            if (authResponse != null)
            {
                _logger.LogInformation($"{DateTime.UtcNow}: User with {authResponse.Email} logged in");
                
                return RedirectToAction("HomePage", "Home");
            }
            
            _logger.LogInformation($"{DateTime.UtcNow}: User with {authResponse.Email} can't logged in");

            return _errorsController.ErrorsPage(401, "Unauthorized");
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
    }
    
    [HttpPost]
    public IActionResult Registration(RegistrationDto registrationDto)
    {
        try
        {
            var registrationResponse = _authService.Registration(registrationDto);

            if (!string.IsNullOrEmpty(registrationResponse))
            {
                _logger.LogInformation(registrationResponse);

                return Login();
            }

            return _errorsController.ErrorsPage(401, $"User with this {registrationDto.Email} " +
                                                     $"is already registered");
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
    }
}