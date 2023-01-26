namespace Visnor.Common.DTO_S.PaymentDto;

public class CreateCardDto
{
    public string Name { get; set; }
    
    public string CardNumber { get; set; }
    
    public string ExpirationYear { get; set; }
    
    public string ExpirationMonth { get; set; }
    
    public string Cvc { get; set; }
}