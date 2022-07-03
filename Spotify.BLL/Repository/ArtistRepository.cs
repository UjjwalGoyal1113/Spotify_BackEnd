using Spotify.BLL.GenericRepository;
using Spotify.BLL.Interfaces.IRepository;
using Spotify.DAL;
using Spotify.Model.DomainModels;

namespace Spotify.BLL.Services.Repository
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context) { }
    }
}
