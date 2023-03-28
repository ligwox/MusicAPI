using AutoMapper;
using MusicAPI.Models;

namespace MusicAPI.AutoMapperProfiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile() 
        {
            CreateMap<Artist, ArtistResponse>();
        }
    }
}
