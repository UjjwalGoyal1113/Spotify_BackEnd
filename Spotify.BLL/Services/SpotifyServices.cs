using AutoMapper;
using Spotify.BLL.Interfaces;
using Spotify.Model.Arguments;
using Spotify.Model.Contracts;
using Spotify.Model.DataTransferObject;
using Spotify.Model.DomainModels;

namespace Spotify.BLL.Services
{
    public class SpotifyServices : ISpotifyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const long maxImageSize = 2048; // 1024 * 2 = 2MB
        private const string baseImageUrl = "http://localhost:83";

        public SpotifyServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddArtist(ArtistDto artistDto)
        {
            if (artistDto == null) return false;

            var artist = _mapper.Map<Artist>(artistDto);

            _unitOfWork.Artist.Add(artist);
            _unitOfWork.Save();
            return true;

        }

        public bool AddSong(SongDto songDto)
        {
            var song = _mapper.Map<Song>(songDto);
            _unitOfWork.Song.Add(song);
            _unitOfWork.Save();
            var songArtists = songDto.ArtistIds.Select(x => new SongArtist()
            {
                ArtistId = x,
                SongId = song.Id
            });
            _unitOfWork.SongArtist.AddRange(songArtists);
            _unitOfWork.Save();
            return true;
        }

        public bool RegisterUser(UserDto userDto)
        {
            if (userDto == null) return false;
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
            return true;
        }

        public List<TopSongDto> TopSongs()
        {
            var result = _unitOfWork.Rating.GetAll().ToList();
            var songs = result.GroupBy(x => new { x.SongId }).Select(x => new TopSongDto()
            {
                SongId = x.Key.SongId,
                SongName = x.First().Song?.Name,
                AverageRating = (int)Math.Ceiling(x.Average(g => g.Ratings)),
                Artist = x.First().Song?.SongArtists?.Select(x => x.Artist?.Name).ToList(),
                CoverImage = x.First().Song?.CoverImage,
                DateOfRelease = x.First().Song.DateOfRelease,
            }).OrderByDescending(x => x.AverageRating).Take(10).Skip(0).ToList();
            return songs;
        }

        public bool SaveRating(RatingDto rateDto)
        {
            var rating = _mapper.Map<Rating>(rateDto);
            _unitOfWork.Rating.Add(rating);
            _unitOfWork.Save();
            return true;
        }



        public List<TopArtistDto> TopArtist()
        {
            var result = _unitOfWork.Rating.GetAll().ToList();
            var artist = result.GroupBy(x => new { x.SongId }).Select(x => new TopArtistDto()
            {
                SongName = x.First().Song?.Name,
                Artist = x.First().Song?.SongArtists?.Select(x => x.Artist?.Name).FirstOrDefault(),
                DateOfBirth = x.First().Song?.SongArtists?.Select(x => x.Artist?.DateOfBirth).FirstOrDefault(),

            }).OrderByDescending(x => x.AverageRating).Take(10).Skip(0).ToList();
            return artist;

        }
        
        public UploadImageRespDto UploadImageInBase64(UploadImageRequestArguments requestArgs)
        {
            var bytes = Convert.FromBase64String(requestArgs.base64Image);
            var folderName = Path.Combine("Uploads", "Images");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var securedFileName = Guid.NewGuid().ToString() + requestArgs.ImageExtension;
            var fullPath = Path.Combine(pathToSave, securedFileName);
            var dbPath = Path.Combine("Images", securedFileName);
            if (bytes.Length > 0 /*&& bytes.Length <= maxImageSize*/)
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
                return new UploadImageRespDto()
                {
                    Success = true,
                    ImageBasePath = baseImageUrl,
                    ReletivePath = "/" + dbPath.Replace("\\", "/"),
                    Message = "ImageUploadSuccesfully"
                };
            }
            return new UploadImageRespDto()
            {
                Success = false,
                ImageBasePath = baseImageUrl,
                ReletivePath = "/" + dbPath.Replace("\\", "/"),
                Message = "File Size cannot be larger than 2MB"
            };
        }

       
    }
}