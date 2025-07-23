using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Models;
using ManagementSystem.Repositories.Interfaces;

namespace ManagementSystem.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockRepository_repository;

        public StockController(IStockRepository repository)
        {
            _repository = repository;
        }
        
        //Get  Stock/AddFootwear
        [HttpGet]
        public IActionResult AddFootwear()
        {
            return View();
        }
        
        //Post   Stock/AddFootwear
        [HttpPost]
        public IActionResult AddFootwear(Footwear footwear)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(footwear);
                TempData["Success"] = "Item added successfully";
                return RedirectToAction("List");
            }

            return View(footwear);
        }
        
        //Get   Stock/List
        public IActionResult List()
        {
            var items = _repository.GetAll();
            return View(items);
        }
        
        [HttpGet]
        public IActionResult AddEquipment()
        {
            return View(); 
        }
        
        [HttpPost]
        public IActionResult AddEquipment(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(equipment);
                TempData["Success"] = "Equipment added successfully!";
                return RedirectToAction("List");
            }

            return View(equipment);
        }
    }
}