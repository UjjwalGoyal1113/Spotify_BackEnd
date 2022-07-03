using System.ComponentModel.DataAnnotations;

namespace Spotify.Model.DomainModels
{
    public class Artist
    {
        [Key]
        public long Id { get; set; } 
        [Required]
        public string? Name { get; set; }      
        public string? Bio { get; set; }     
        [Required]
        public DateTime DateOfBirth { get; set; }     
        public virtual ICollection<SongArtist>? SongArtists { get; set; }
       
    }
}
