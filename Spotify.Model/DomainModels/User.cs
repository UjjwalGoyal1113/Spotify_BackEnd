using System.ComponentModel.DataAnnotations;

namespace Spotify.Model.DomainModels
{
    public class User
    {
        [Key]
        public long Id { get; set; }   
        [Required]
        public string? Name { get; set; }   
        [Required]
        [EmailAddress]
        public string? Email { get; set; }      
        
    }
}
