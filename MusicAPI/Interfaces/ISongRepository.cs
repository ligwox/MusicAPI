using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Interfaces
{
    public interface ISongRepository : IRepository<Song>
    {
        public Task<IEnumerable<Song>> GetNewSongs(int amount);
        public Task<IEnumerable<Song>> GetSearchSongs(string query);
        public Task<IEnumerable<Song>> GetFeaturedSongs();
    }
}
