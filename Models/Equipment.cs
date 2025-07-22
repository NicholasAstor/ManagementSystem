namespace ManagementSystem.Models
{
    public class Equipment : Item
    {
        public string Specifications { get; set; } // Aqui vão entrar especificações como peso, tamanho, etc... assim não precisando da criação de várias classes distintas
    }
}