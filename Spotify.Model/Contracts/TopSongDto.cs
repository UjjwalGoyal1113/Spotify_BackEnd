using Newtonsoft.Json;

namespace Spotify.Model.Contracts
{
    public class TopSongDto
    {
        public long SongId { get; set; }
        public string SongName { get; set; }
        [JsonIgnore]
        public int AverageRating { get; set; }
        public string CoverImage { get; set; }
        public DateTime DateOfRelease { get; set; }
        public List<string> Artist { get; set; }
    }
}
