using Microsoft.AspNetCore.Mvc;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.PaymentDto;

namespace Visnor.Controllers;

public class PaymentsController : Controller
{
    private readonly ILogger<PaymentsController> _logger;
    private readonly ErrorsController _errorsController;
    private readonly IPaymentsService _paymentsService;

    public PaymentsController(ILogger<PaymentsController> logger,ErrorsController errorsController,
        IPaymentsService paymentsService)
    {
        _logger = logger;
        _errorsController = errorsController;
        _paymentsService = paymentsService;
    }

    public IActionResult Customer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateCustomer(CreateCustomerDto createCustomerDto,
        CancellationToken ct)
    {
        try
        {
            var createdCustomer = _paymentsService.AddStripeCustomerAsync(
                createCustomerDto, ct);

            return Payment();
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
    }
    
    public IActionResult Payment()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreatePayment(CreatePaymentDto createPaymentDto,
        CancellationToken ct)
    {
        try
        {
            var createdPayment =  _paymentsService.AddStripePaymentAsync(
                createPaymentDto, ct);

            return OkPayments();
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
    }
    
    public IActionResult OkPayments()
    {
        return View();
    }
}