namespace ManagementSystem.Models
{
    public class Equipment : Item
    {
        public string Specifications { get; set; } // Aqui vão entrar especificações como peso, tamanho, etc... assim não precisando da criação de várias classes distintas

        public Equipment(string? sku, Brand brand, Modalities modalities, string name, string? image, string description, double price, DateTime? manufacturedIn, string specifications)
            : base(sku, brand, modalities, name, image, description, price, manufacturedIn)
        {
            Specifications = specifications;
        }
    }
}