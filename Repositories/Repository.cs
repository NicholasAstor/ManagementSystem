using ManagementSystem.Models;
using ManagementSystem.Repositories.Interfaces;

namespace ManagementSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : Item
    {
        public List<T> _repo;

        public Repository()
        {
            _repo = new List<T>();
        }

        public IEnumerable<T> GetAll() => _repo;

        public void Add(T item) => _repo.Add(item);

        public void Update(int id, T updatedItem)
        {
            var item = _repo.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _repo.Remove(item);
                _repo.Add(updatedItem);
            }
            else
            {
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }
        }
    }
}