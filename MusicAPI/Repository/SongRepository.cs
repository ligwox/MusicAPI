using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Interfaces;
using MusicAPI.Models;
using System.Collections;
using System.Runtime.Versioning;

namespace MusicAPI.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly ApiDbContext _dbContext;
        public SongRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Song> AddAsync(Song entity)
        {
            await _dbContext.Songs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Song> DeleteAsync(int id)
        {
            var song = await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Songs.Remove(song);
            await _dbContext.SaveChangesAsync();
            return song;
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            var songs = await _dbContext.Songs.ToListAsync();
            return songs;
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            var song = await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id == id);
            return song;
        }

        public async Task<IEnumerable<Song>> GetFeaturedSongs()
        {
            var songs = await _dbContext.Songs.Where(x => x.IsFeatured).ToListAsync();
            return songs;
        }

        public async Task<IEnumerable<Song>> GetNewSongs(int amount)
        {
            var songs = await _dbContext.Songs
                .OrderByDescending(x=>x.UploadedDate)
                .Take(amount)
                .ToListAsync();
            return songs;
        }

        public async Task<IEnumerable<Song>> GetSearchSongs(string query)
        {
            var songs = await _dbContext.Songs.Where(x => x.Title.StartsWith(query)).ToListAsync();
            return songs;
        }

        public async Task<Song> UpdateAsync(int id, Song entity)
        {
            var song = await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id == id);
            if (song == null)
                return null;
            song.Title = entity.Title;
            song.Language = entity.Language;
            song.Duration = entity.Duration;
            song.ArtistId = entity.ArtistId;
            song.AlbumId = entity.AlbumId;
            song.AudioFile = entity.AudioFile;
            song.AudioUrl = entity.AudioUrl;
            song.Image = entity.Image;
            song.ImageUrl = entity.ImageUrl;
            song.IsFeatured = entity.IsFeatured;
            await _dbContext.SaveChangesAsync();
            return song;
        }
    }
}
