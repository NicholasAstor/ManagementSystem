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

        public void Add(T item)
        {
            _repo.Add(item);
        }
    }
}