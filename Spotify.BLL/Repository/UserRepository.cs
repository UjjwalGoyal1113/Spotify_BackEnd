using Spotify.BLL.GenericRepository;
using Spotify.BLL.Interfaces.IRepository;
using Spotify.DAL;
using Spotify.Model.DomainModels;


namespace Spotify.BLL.Services.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
