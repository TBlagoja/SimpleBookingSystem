using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id); 
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
