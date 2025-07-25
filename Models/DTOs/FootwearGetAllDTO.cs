namespace ManagementSystem.Models.DTOs
{
    public class FootwearGetAllDTO
    {
        public Footwear Footwear { get; set; }
        public int Quantity { get; set; }
        
        public string BrandName => Footwear.Brand.ToString();
        public string ModalityName => Footwear.Modalities.ToString();
        public string TypeName => Footwear.TypeOfFootwear.ToString();
    }
}