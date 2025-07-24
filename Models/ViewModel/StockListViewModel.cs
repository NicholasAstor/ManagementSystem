using ManagementSystem.Models;

namespace ManagementSystem.Models
{
    public class StockListViewModel
    {
        public IEnumerable<Footwear> products { get; set; } = new List<Footwear>();
    }
}