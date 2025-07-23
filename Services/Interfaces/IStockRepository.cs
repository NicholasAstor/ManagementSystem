using System.Collections.Generic;
using ManagementSystem.Models;

namespace ManagementSystem.Services.Interfaces
{
    public interface IStockRepository
    {
        void Add(Item item);
        List<Item> GetAll();
        
        List<Brand> GetBrands();
        List<Type> GetTypes();
        List<Modalities> GetModalities();
    }
}