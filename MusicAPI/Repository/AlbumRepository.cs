using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Interfaces;
using MusicAPI.Models;

namespace MusicAPI.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApiDbContext _context;
        public AlbumRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Album> AddAsync(Album entity)
        {
            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Album> GetAlbumDetails(int albumId)
        {
            var albumDetails = await _context.Albums
                .Where(x => x.Id == albumId)
                .Include(x => x.Songs)
                .FirstOrDefaultAsync();
            return albumDetails;
        }

        public async Task<Album> DeleteAsync(int id)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(x=>x.Id == id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            var albums = await _context.Albums.Include(x=>x.Songs).ToListAsync();
            return albums;
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            var albumDetails = await _context.Albums.FirstOrDefaultAsync();
            return albumDetails;
        }

        public async Task<Album> UpdateAsync(int id, Album entity)
        {
            var album = await _context.Albums.FirstOrDefaultAsync();
            if (album == null)
                return null;
            album.Image = entity.Image;
            album.Name = entity.Name;
            album.ArtistId = entity.ArtistId;
            album.ImageUrl = entity.ImageUrl;
            await _context.SaveChangesAsync();
            return album;
        }
    }
}
