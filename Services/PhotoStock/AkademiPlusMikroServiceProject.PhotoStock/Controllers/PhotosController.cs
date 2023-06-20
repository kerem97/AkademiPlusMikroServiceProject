using AkademiPlusMikroServiceProje.Shared.ControllerBases;
using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.PhotoStock.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken token)
        {
            if (photo != null & photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, token);
                var returnPath = photo.FileName;
                PhotoDto photoDto = new()
                {
                    Url = returnPath,
                };
                return CreateActionResultInstance(Response<PhotoDto>.Success(200, photoDto));

            }
            else
            {
                return CreateActionResultInstance(Response<PhotoDto>.Fail(400, "Fotoğraf Bulunamadı"));
            }
        }
    }

}
