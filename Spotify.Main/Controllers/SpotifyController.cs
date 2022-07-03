using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.BLL.Interfaces;
using Spotify.Model.Contracts;
using Spotify.Model.DataTransferObject;
using Spotify.Model.DomainModels;

namespace Spotify.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        
        
        private readonly ISpotifyServices _spotifyServices;

        public SpotifyController(ISpotifyServices spotifyServices)
        {
           
           _spotifyServices = spotifyServices;
        }
       // [HttpGet]
        //public IEnumerable<User> GetAllUsers()
        //{
        //    return _spotifyServices.
        //}
        [HttpPost("AddArtist")]
        public IActionResult AddArtist(ArtistDto artistDto)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    _spotifyServices.AddArtist(artistDto);
                }
                    return StatusCode(200, "Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddSong")]
        public IActionResult AddSong(SongDto songDto)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    _spotifyServices.AddSong(songDto);
                }
                return StatusCode(200, "Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(UserDto userDto)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    _spotifyServices.RegisterUser(userDto);
                }
                return StatusCode(200, "Registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveRating")]
        public IActionResult SaveRating(RatingDto ratingDto)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    _spotifyServices.SaveRating(ratingDto);
                }
                return StatusCode(200, "Saved!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Top10Songs")]
        public ActionResult<List<TopSongDto>> TopSongs()
        {
            try
            {
               var result =  _spotifyServices.TopSongs();
                return result;
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Top10Artist")]
        public ActionResult<List<TopArtistDto>> TopArtist()
        {
            try
            {
                var result = _spotifyServices.TopArtist();
                return result;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
