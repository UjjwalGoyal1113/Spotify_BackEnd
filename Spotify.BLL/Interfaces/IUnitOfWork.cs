using Spotify.BLL.Interfaces.IRepository;

namespace Spotify.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User
        {
            get;
        }
        IRatingRepository Rating
        {
            get;
        }
        ISongRepository Song
        {
            get;
        }
        ISongArtistRepository SongArtist
        {
            get;
        }
        IArtistRepository Artist
        {
            get;
        }
        int Save();
    }
}
