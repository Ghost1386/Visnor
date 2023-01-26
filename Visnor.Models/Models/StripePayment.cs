namespace Visnor.Models.Models;

public class StripePayment
{
    public string PaymentId { get; set; }
    
    public string CustomerId { get; set; }
    
    public string ReceiptEmail { get; set; }
    
    public string Description { get; set; }
    
    public string Currency { get; set; }
    
    public long Amount { get; set; }
}