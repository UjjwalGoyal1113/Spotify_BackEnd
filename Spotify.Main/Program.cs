using Microsoft.Extensions.FileProviders;
using Spotify.BLL.Interfaces;
using Spotify.BLL.Services;
using Spotify.BLL.UnitOfWork;
using Spotify.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<AppDbContext, AppDbContext>();
builder.Services.AddTransient<ISpotifyServices, SpotifyServices>();
//builder.Services.AddDbContext<AppDbContext>(, b => b.MigrationsAssembly("Spotify.Main")).UseLazyLoadingProxies()
//       options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")/**/));
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
}
DirectoryInfo imageFolder = new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "Uploads/Images"));
if(!imageFolder.Exists)
{
    imageFolder.Create();
}
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Uploads/Images")),
    RequestPath = "/Images"
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
