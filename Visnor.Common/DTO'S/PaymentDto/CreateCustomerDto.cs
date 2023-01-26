namespace Visnor.Common.DTO_S.PaymentDto;

public class CreateCustomerDto
{
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public CreateCardDto CreditCard { get; set; }
}