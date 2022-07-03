using System.ComponentModel.DataAnnotations;

namespace Spotify.Model.DataTransferObject
{
    public class ArtistDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name can longer than 100 characters!")]
        public string name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Bio can longer than 255 characters!")]
        public string Bio { get; set; }
        
    }
}
