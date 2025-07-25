using ManagementSystem.Models;

namespace ManagementSystem.Repositories.Interfaces
{
    public interface IRepository<T, Y> where T : Item
    {
        void Add(T item);
        void Delete(int id);
        IEnumerable<Y> GetAll();
        void Update(int id, T updatedItem);
        T GetById(int id);
        void IncreaseQuantity(int id);
        void DecreaseQuantity(int id);
    }
}