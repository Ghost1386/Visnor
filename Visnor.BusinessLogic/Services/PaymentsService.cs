using Stripe;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.PaymentDto;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class PaymentsService : IPaymentsService
{
    private readonly ChargeService _chargeService;
    private readonly CustomerService _customerService;
    private readonly TokenService _tokenService;

    public PaymentsService(ChargeService chargeService, CustomerService customerService, 
        TokenService tokenService)
    {
        _chargeService = chargeService;
        _customerService = customerService;
        _tokenService = tokenService;
    }
    
    public async Task<StripeCustomer> AddStripeCustomerAsync(CreateCustomerDto customer, CancellationToken ct)
    {
        var tokenOptions = new TokenCreateOptions
        {
            Card = new TokenCardOptions
            {
                Name = customer.Name,
                Number = customer.CreditCard.CardNumber,
                ExpYear = customer.CreditCard.ExpirationYear,
                ExpMonth = customer.CreditCard.ExpirationMonth,
                Cvc = customer.CreditCard.Cvc
            }
        };
        
        var stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);
        
        var customerOptions = new CustomerCreateOptions
        {
            Name = customer.Name,
            Email = customer.Email,
            Source = stripeToken.Id
        };
        
        var createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

        var stripeCustomer = new StripeCustomer
        {
            Name = createdCustomer.Name,
            Email = createdCustomer.Email,
            CustomerId = createdCustomer.Id
        };
        
        return stripeCustomer;
    }

    public async Task<StripePayment> AddStripePaymentAsync(CreatePaymentDto payment, CancellationToken ct)
    {
        var paymentOptions = new ChargeCreateOptions 
        {
            Customer = payment.CustomerId,
            ReceiptEmail = payment.ReceiptEmail,
            Description = payment.Description,
            Currency = payment.Currency,
            Amount = payment.Amount
        };
        
        var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

        var stripePayment = new StripePayment
        {
            PaymentId = createdPayment.Id,
            CustomerId = createdPayment.CustomerId,
            ReceiptEmail = createdPayment.ReceiptEmail,
            Description = createdPayment.Description,
            Currency = createdPayment.Currency,
            Amount = createdPayment.Amount
        };

        return stripePayment;
    }
}