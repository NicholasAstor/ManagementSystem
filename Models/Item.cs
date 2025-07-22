namespace ManagementSystem.Models
{
    public abstract class Item
    {
        public int _lastId = 0;
        public int Id { get; } // Propriedade read-only
        public string SKU { get; set; } // Funciona como um ID que é dado pelo fornecedor, tem que ser possível editar 
        public Brand brand { get; set; } // Marca do item: Nike, Adidas
        public Modalities Modalities { get; set; } // Tipo do item: Futebol, Basquete
        public string Name { get; set; }
        public string Image { get; set; } // Ainda vou pensar melhor se vamos armazenar o path ou um link da imagem, se formos trabalhar com JSON pode acabar sendo diferente
        public string Description { get; set; }
        public double Price { get; set; } // Poderia ser float, caso o programa venha a ser pesado pode ser alterado
        public DateTime ManufacturedIn { get; set; }
    }
}