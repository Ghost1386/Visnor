using Microsoft.AspNetCore.Http;
using Visnor.BusinessLogic.Interfaces;

namespace Visnor.BusinessLogic.Services;

public class PhotoService : IPhotoService
{
    public string ConvertPhotoInByteString(IFormFile file)
    {
        var photosInByteString = string.Empty;
        
        if (file.Length > 0)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            photosInByteString = Convert.ToBase64String(fileBytes);
        }
        
        return photosInByteString;
    }
}