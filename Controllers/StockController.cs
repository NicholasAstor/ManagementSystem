using ManagementSystem.Models;
using ManagementSystem.Models.Enum;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;

namespace ManagementSystem.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        public IActionResult Index()
        {
            var items = _stockService.GetAllItems();
            return View(items);
        }

        [HttpPost("stock/add")]
        public ActionResult<Item> Add([FromForm] string sku, [FromForm] Brand brand, [FromForm] Modalities modalities, [FromForm] string name, [FromForm] string? image, [FromForm] string description, [FromForm] double price, [FromForm] DateTime? manufacturedIn, [FromForm] byte size, [FromForm] TypeOfFootwear typeOfFootwear)
        {
            var item = new Footwear(sku, Brand.Nike, Modalities.Futebol, name, image, description, price, new DateTime(2005, 03, 21), size, TypeOfFootwear.Society);
            _stockService.EntryOfProducts(item);
            return Ok(item);
        }
    }
}