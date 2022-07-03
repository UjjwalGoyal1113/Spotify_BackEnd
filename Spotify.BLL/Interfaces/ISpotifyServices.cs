using Spotify.Model.Arguments;
using Spotify.Model.Contracts;
using Spotify.Model.DataTransferObject;

namespace Spotify.BLL.Interfaces
{
    public interface ISpotifyServices
    {
        bool AddArtist(ArtistDto artistDto);
        bool AddSong( SongDto songDto);
        bool RegisterUser(UserDto userDto);
        bool SaveRating(RatingDto rateDto);
        List<TopSongDto> TopSongs();
        List<TopArtistDto> TopArtist();
        UploadImageRespDto UploadImageInBase64(UploadImageRequestArguments requestArgs);
    }
}
