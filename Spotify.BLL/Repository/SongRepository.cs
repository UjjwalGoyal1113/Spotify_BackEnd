using Spotify.BLL.GenericRepository;
using Spotify.BLL.Interfaces.IRepository;
using Spotify.DAL;
using Spotify.Model.DomainModels;

namespace Spotify.BLL.Services.Repository
{

    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context) { }
    }
}
