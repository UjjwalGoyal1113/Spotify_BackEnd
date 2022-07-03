using AutoMapper;
using Spotify.Model.Contracts;
using Spotify.Model.DataTransferObject;
using Spotify.Model.DomainModels;

namespace Spotify.Main
{
    public class ApplicationMapping:Profile
    {
        public ApplicationMapping()
        {
            CreateMap<ArtistDto,Artist>().ReverseMap();
            CreateMap<SongDto, Song>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RatingDto, Rating>().ReverseMap();
            CreateMap<SongDto,SongArtist>()
                                              .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistIds));
            CreateMap<SongDto, SongArtist>();
        }
    }
}
