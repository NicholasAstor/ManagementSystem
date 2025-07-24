using ManagementSystem.Models;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Models.Enum;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ManagementSystem.Controllers
{
    [Route("stock")]
    public class StockController : Controller
    {
        private readonly IService<Footwear, FootwearGetAllDTO> _service;

        public StockController(IService<Footwear, FootwearGetAllDTO> service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index(string? searchTerm)
        {
            var items = _service.GetAllItems();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                items = items
                    .Where(i => i.Footwear.Name != null &&
                                i.Footwear.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }
            return View(items);
        }

        [HttpGet("add")]
        public IActionResult addItem()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] string sku, [FromForm] Brand brand, [FromForm] Modalities modalities,
                                 [FromForm] string name, [FromForm] string? image, [FromForm] string description,
                                 [FromForm] double price, [FromForm] DateTime? manufacturedIn,
                                 [FromForm] byte size, [FromForm] TypeOfFootwear typeOfFootwear)
        {
            var item = new Footwear(sku, brand, modalities, name, image, description, price, manufacturedIn, size, typeOfFootwear);
            _service.EntryOfProducts(item);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id) => Content($"Editar produto ID {id}");

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id) => Content($"Excluir produto ID {id}");
    }
}
