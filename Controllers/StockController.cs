using ManagementSystem.Models;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Models.Enum;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;

namespace ManagementSystem.Controllers
{
    public class StockController : Controller
    {
        private readonly IService<Footwear, FootwearGetAllDTO> _service;

        public StockController(IService<Footwear, FootwearGetAllDTO> service)
        {
            _service = service;
        }

        [HttpGet("stock")]
        public IActionResult Index()
        {
            var items = _service.GetAllItems();
            return Ok(items);    
        }

        [HttpPost("stock/add")]
        public ActionResult<Item> Add([FromForm] string sku, [FromForm] Brand brand, [FromForm] Modalities modalities, [FromForm] string name, [FromForm] string? image, [FromForm] string description, [FromForm] double price, [FromForm] DateTime? manufacturedIn, [FromForm] byte size, [FromForm] TypeOfFootwear typeOfFootwear)
        {
            var item = new Footwear(sku, Brand.Nike, Modalities.Futebol, name, image, description, price, new DateTime(2005, 03, 21), size, TypeOfFootwear.Society);
            _service.EntryOfProducts(item);
            return Ok(item);
        }
    }
}