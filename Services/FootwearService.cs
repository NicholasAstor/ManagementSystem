using ManagementSystem.Models;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Repositories.Interfaces;
using ManagementSystem.Services.Interfaces;

namespace ManagementSystem.Services
{
    public class FootwearService : IService<Footwear, FootwearGetAllDTO>
    {
        private readonly IRepository<Footwear, FootwearGetAllDTO> _repo;

        public FootwearService(IRepository<Footwear, FootwearGetAllDTO> repo)
        {
            _repo = repo;
        }

        public void EntryOfProducts(Footwear item) => _repo.Add(item);
        public void OutOfProducts(int id) => _repo.Delete(id);
        public IEnumerable<FootwearGetAllDTO> GetAllItems() => _repo.GetAll();
        public void UpdateItemInfo(int id, Footwear updatedItem) => _repo.Update(id, updatedItem);
        public Footwear GetById(int id) => _repo.GetById(id);

        public void CountSumQuantity(int id) => _repo.IncreaseQuantity(id);
        public void CountDecreaseQuantity(int id) => _repo.DecreaseQuantity(id);
    }
}