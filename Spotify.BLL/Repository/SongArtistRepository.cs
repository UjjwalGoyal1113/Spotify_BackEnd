using Spotify.BLL.GenericRepository;
using Spotify.BLL.Interfaces.IRepository;
using Spotify.DAL;
using Spotify.Model.DomainModels;

namespace Spotify.BLL.Services.Repository
{
    public class SongArtistRepository : GenericRepository<SongArtist>, ISongArtistRepository
    {
        public SongArtistRepository(AppDbContext context) : base(context) { }
    }
}
