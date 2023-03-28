using MusicAPI.Models;

namespace MusicAPI.Interfaces
{
    public interface IRepository<Tmodel> where Tmodel : class
    {
        public Task<IEnumerable<Tmodel>> GetAllAsync();
        public Task<Tmodel> GetByIdAsync(int id);
        public Task<Tmodel> DeleteAsync(int id);
        public Task<Tmodel> UpdateAsync(int id, Tmodel entity);
        public Task<Tmodel> AddAsync(Tmodel entity);
    }
}
