using ManagementSystem.Models.Enum;

namespace ManagementSystem.Models
{
    public class Footwear : Item
    {
        public byte Size { get; set; }
        public TypeOfFootwear TypeOfFootwear { get; set; } // Tipo de chuteira 

        public Footwear(string sku, Brand brand, Modalities modalities, string name, string? image, string description, double price, DateTime? manufacturedIn, byte size, TypeOfFootwear typeOfFootwear)
            : base(sku, brand, modalities, name, image, description, price, manufacturedIn)
        {
            Size = size;
            TypeOfFootwear = typeOfFootwear;
        }
    }
}