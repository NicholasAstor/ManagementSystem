namespace ManagementSystem.Models.ViewModel
{
    public class UpdateQuantityRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Action { get; set; }
    }
}
