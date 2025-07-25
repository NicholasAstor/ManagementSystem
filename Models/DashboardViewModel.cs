using ManagementSystem.Models.DTOs;
using System.Collections.Generic;

namespace ManagementSystem.Models
{
    public class DashboardViewModel
    {
        public int TotalItems { get; set; }
        public int ItemsInStock { get; set; }
        public List<FootwearGetAllDTO> RecentFootwear { get; set; }
    }
}