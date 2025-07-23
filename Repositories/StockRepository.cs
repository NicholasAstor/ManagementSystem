using System.Collections.Generic;
using ManagmentSystem.Models;
using ManagementSystem.Repositories.Interfaces;

namespace ManagementSystem.Repositories
{
    public class StockRepository : IStockRepository
    {
        //lista estática para simular banco de dados em a
        private static List<Item> _items = new List<Item>();

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public List<Item> GetAll()
        {
            return _items;
        }
    }
}