using System.ComponentModel.DataAnnotations;

namespace Spotify.Model.Contracts
{
    public class RatingDto
    {
        [Range(1,5)]
        public int Ratings { get; set; }
        public long UserId { get; set; }
        public long SongId { get; set; }

    }
}
