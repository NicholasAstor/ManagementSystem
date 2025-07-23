using ManagementSystem.Models;
using ManagementSystem.Repositories.Interfaces;
using ManagementSystem.Services.Interfaces;

namespace ManagementSystem.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<Item> _repo;

        public StockService(IRepository<Item> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Item> GetAllItems() => _repo.GetAll();

        public void EntryOfProducts(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }

            _repo.Add(item);
        }

        public void UpdateItemInfo(int id, Item updatedItem) => _repo.Update(id, updatedItem);
    }
}