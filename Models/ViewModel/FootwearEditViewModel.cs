using ManagementSystem.Models.Enum;

namespace ManagementSystem.Models.ViewModel
{
    public class FootwearEditViewModel
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public Brand Brand { get; set; }
        public Modalities Modalities { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime? ManufacturedIn { get; set; }
        public byte Size { get; set; }
        public TypeOfFootwear TypeOfFootwear { get; set; }
    }
}
