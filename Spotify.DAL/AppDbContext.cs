using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spotify.Model.DomainModels;

namespace Spotify.DAL
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("Spotify.DAL")).UseLazyLoadingProxies();
        }
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //    base.Database.EnsureCreated();
        //}
        public DbSet<User>? Users { get; set; }
        public DbSet<Artist>? Artists { get; set; }
        public DbSet<Song>? Songs { get; set; }
        public DbSet<SongArtist>? SongArtists { get; set; }
        public DbSet<Rating>? Ratings { get; set; }


    }
}
