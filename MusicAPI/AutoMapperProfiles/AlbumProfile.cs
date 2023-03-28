using AutoMapper;
using MusicAPI.Models;

namespace MusicAPI.AutoMapperProfiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile() 
        {
            CreateMap<Album, AlbumResponse>();
        }   
    }
}
