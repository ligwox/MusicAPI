using MusicAPI.Models;

namespace MusicAPI.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        public Task<Album> GetAlbumDetails(int artistId);
    }
}
