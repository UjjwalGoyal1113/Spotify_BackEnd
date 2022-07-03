using System.ComponentModel.DataAnnotations;

namespace Spotify.Model.DomainModels
{
    public class Rating
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int Ratings { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long SongId { get; set; }
        public virtual Song? Song { get; set; }
        public long ArtistId { get; set; }
        
    }
}
