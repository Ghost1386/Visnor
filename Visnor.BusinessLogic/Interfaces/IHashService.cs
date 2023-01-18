namespace Visnor.BusinessLogic.Interfaces;

public interface IHashService
{
    string CreateHashPassword(string email, string password);
    
    string VerifyHashPassword(string email, string password);
}