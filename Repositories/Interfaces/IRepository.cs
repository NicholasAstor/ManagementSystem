using ManagementSystem.Models;

namespace ManagementSystem.Repositories.Interfaces
{
    public interface IRepository<T> where T : Item
    {
        void Add(T item);
        // void Delete(int id);
        IEnumerable<T> GetAll();
        // int CountByType<T>() where T : Item;
        // int CountByBrand(Brand brand);
        void Update(int id, T updatedItem);
    }
}