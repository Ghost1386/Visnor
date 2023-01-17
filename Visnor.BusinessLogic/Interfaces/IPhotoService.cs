using Microsoft.AspNetCore.Http;

namespace Visnor.BusinessLogic.Interfaces;

public interface IPhotoService
{
    string ConvertPhotoInByteString(IFormFile file);
}