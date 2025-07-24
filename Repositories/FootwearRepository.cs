using ManagementSystem.Models;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Repositories.Interfaces;

namespace ManagementSystem.Repositories
{
    public class FootwearRepository : IRepository<Footwear, FootwearGetAllDTO> 
    {
        private List<Footwear> _listFootwears;
        private Dictionary<string, int> _footwearsDict;

        public FootwearRepository()
        {
            _listFootwears = new List<Footwear>();
            _footwearsDict = new Dictionary<string, int>();
        }

        public void Add(Footwear item)
        {
            if (item == null)
            {
                return;
            }

            if (_footwearsDict.ContainsKey(item.SKU)) // TODO: Revisar possible null reference exception
            {
                var value = _footwearsDict.GetValueOrDefault(item.SKU);
                _footwearsDict[item.SKU] = ++value;
                return;
            }
            else
            {
                _footwearsDict.Add(item.SKU, 1);
                _listFootwears.Add(item);
                return;
            }
        }
        
        public void Delete(int id)
        {
            var item = _listFootwears.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _listFootwears.Remove(item);
                if (_footwearsDict.ContainsKey(item.SKU)) // TODO: Revisar possible null reference exception
                {
                    var value = _footwearsDict.GetValueOrDefault(item.SKU);
                    if (value > 1)
                    {
                        _footwearsDict[item.SKU] = --value;
                    }
                    else
                    {
                        _footwearsDict[item.SKU] = 0;
                    }
                }
            }
        }

        public IEnumerable<FootwearGetAllDTO> GetAll()
        {
            var returnList = _listFootwears.Select(f => new FootwearGetAllDTO
            {
                Footwear = f,
                Quantity = _footwearsDict.GetValueOrDefault(f.SKU, 0)
            });

            return returnList;
        }
        public void Update(int id, Footwear updatedItem)
        {
            var item = _listFootwears.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _listFootwears.Remove(item);
                _listFootwears.Add(updatedItem);
            }
            else
            {
                return;
            }
        }

        public Footwear GetById(int id) => _listFootwears.FirstOrDefault(i => i.Id == id);
    }
}