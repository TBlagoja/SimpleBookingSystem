using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly ApplicationContext _context;

        public ResourceRepository(ApplicationContext context) 
        {
            _context = context;
        }
        public async Task<List<Resource>> GetResourcesAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task<Resource> GetResourcesByIdAsync(int id)
        {
            return await _context.Resources.FindAsync(id);
        }
    }
}
