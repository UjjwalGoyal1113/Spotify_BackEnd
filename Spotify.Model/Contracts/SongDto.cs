using Spotify.Model.DomainModels;

namespace Spotify.Model.Contracts
{
    public class SongDto
    {
        public string? Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string? CoverImage { get; set; }
        public List<long> ArtistIds { get; set; }
       
    }
}
