using ManagementSystem.Models;
using ManagementSystem.Models.Enum;

namespace ManagementSystem.Services.Interfaces
{
    public interface IService<T, Y>
    {
        void EntryOfProducts(T item);
        void OutOfProducts(int id);
        IEnumerable<Y> GetAllItems();
        void UpdateItemInfo(int id, T updatedItem);
        T GetById(int id);
    }
}