using ManagementSystem.Models;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IService<Footwear, FootwearGetAllDTO>_footwearService;

        public DashboardController(IService<Footwear, FootwearGetAllDTO> footwearService)
        {
            _footwearService = footwearService;
        }

        public IActionResult Index()
        {
            var allItems = _footwearService.GetAllItems().ToList();
            
            var viewModel = new DashboardViewModel
            {
                TotalItems = allItems.Count,
                ItemsInStock = allItems.Sum(i => i.Quantity),
                RecentFootwear = allItems.Take(4).ToList()
            };

            return View(viewModel);
        }
    }
}