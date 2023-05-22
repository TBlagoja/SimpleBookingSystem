using Core.Entities;

namespace Core.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T booking);
        Task<List<T>> ListAllAsync();
    }
}
