using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Interfaces;
using MusicAPI.Models;

namespace MusicAPI.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApiDbContext _context;
        public ArtistRepository(ApiDbContext context) { 
            _context = context;
        }
        public async Task<Artist> AddAsync(Artist entity)
        {
            await _context.Artists.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Artist> GetArtistDetails(int artistId)
        {
            var artist = await _context.Artists
                .Where(x => x.Id == artistId)
                .Include(x => x.Songs)
                .FirstOrDefaultAsync();
            return artist;
        }

        public async Task<Artist> DeleteAsync(int id)
        {
            var artist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (artist == null)
                return null;
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var artist = await _context.Artists
                .Include(x => x.Songs)
                .Include(x => x.Albums)
                .ToListAsync();
            return artist;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            var artist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);
            return artist;
        }

        public async Task<Artist> UpdateAsync(int id, Artist entity)
        {
            var artist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (artist == null)
                return null;
            artist.Name = entity.Name;
            artist.Gender = entity.Gender;
            artist.Image = entity.Image;
            artist.ImageUrl = entity.ImageUrl;
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
