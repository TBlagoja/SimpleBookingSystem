using Core.Entities;

namespace Core.Interface
{
    public interface IResourceRepository
    {
        Task<Resource> GetResourcesByIdAsync(int id);
        Task<List<Resource>> GetResourcesAsync();
    }
}
