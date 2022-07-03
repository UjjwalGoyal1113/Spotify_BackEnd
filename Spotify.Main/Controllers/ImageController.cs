using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.BLL.Interfaces;
using Spotify.BLL.Services;
using Spotify.Model.Arguments;
using Spotify.Model.Contracts;

namespace Spotify.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ISpotifyServices _spotifyServices;

        public ImageController(ISpotifyServices spotifyServices)
        {
            _spotifyServices = spotifyServices;
        }
        [HttpPost("UploadImageInBase64")]
        public ActionResult<UploadImageRespDto> UploadImageInBase64(UploadImageRequestArguments reqArgs)
        {
            try
            {
                var result = _spotifyServices.UploadImageInBase64(reqArgs);
                if(result.Success)
                {
                    return  Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
