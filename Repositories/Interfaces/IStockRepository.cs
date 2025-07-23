using System.Collection.Generic;
using ManagementSystem.Models;

namespace ManagementSystem.Repositories.Interfaces
{
    public interface IStockRepository // Alguns exemplos, não precisamos fazer desse jeito
    {
        // void Add(Item item);
        void Add(Item item); 
        List<Item> GetAll();
        
        // void Delete(int id);
        // IEnumerable<Item> GetAll();
        // int CountByType<T>() where T : Item;
        // int CountByBrand(Brand brand);
    }
}