using Spotify.BLL.Interfaces;
using Spotify.BLL.Interfaces.IRepository;
using Spotify.BLL.Services.Repository;
using Spotify.DAL;

namespace Spotify.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Song = new SongRepository(_context);
            Artist = new ArtistRepository(_context);
            SongArtist = new SongArtistRepository(_context);
            Rating = new RatingRepository(_context);
        }

        public IUserRepository User
        {
            get;
            private set;
        }
        public IRatingRepository Rating
        {
            get;
            private set;
        }
        public ISongRepository Song
        {
            get;
            private set;
        }
        public ISongArtistRepository SongArtist
        {
            get;
            private set;
        }
        public IArtistRepository Artist
        {
            get;
            private set;
        }

        

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
