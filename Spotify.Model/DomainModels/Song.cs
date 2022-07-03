using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model.DomainModels
{
    public class Song
    {
        [Key]
        public long Id { get; set; }    
        [Required]
        public string? Name { get; set; }       
        public DateTime DateOfRelease { get; set; }
        public string? CoverImage { get; set; }
        public virtual ICollection<SongArtist>? SongArtists { get; set; }        
      
    }
}
