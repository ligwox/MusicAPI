using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;

namespace MusicAPI.Interfaces
{
    public interface IArtistRepository : IRepository<Artist>
    {
        public Task<Artist> GetArtistDetails(int artistId);
    }
}
