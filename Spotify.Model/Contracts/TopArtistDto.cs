using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.Model.Contracts
{
    public class TopArtistDto
    {
        public string Artist { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SongName { get; set; }
        [JsonIgnore]
        public int AverageRating { get; set; }
    }
}