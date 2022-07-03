using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model.DomainModels
{
    public class SongArtist
    {
        [Key]
        public long Id { get; set; }
        public long ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
        public long SongId { get; set; }
        public virtual Song? Song { get; set; }
    }
}
