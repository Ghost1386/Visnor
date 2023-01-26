using Visnor.Common.DTO_S.PaymentDto;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IPaymentsService
{
    Task<StripeCustomer> AddStripeCustomerAsync(CreateCustomerDto customer, CancellationToken ct);
    Task<StripePayment> AddStripePaymentAsync(CreatePaymentDto payment, CancellationToken ct);
}