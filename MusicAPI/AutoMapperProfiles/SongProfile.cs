using AutoMapper;
using MusicAPI.Models;

namespace MusicAPI.AutoMapperProfiles
{
    public class SongProfile : Profile
    {

        public SongProfile()
        {
            CreateMap<Song, SongResponse>();
        }
    }
}
