using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Equipment : Item
    {
        
        [Required(ErrorMessage = "please enter the specifications")]
        [StringLength(200, ErrorMessage = "Specifications must be under 200 characters")]
        public string Specifications { get; set; } // Aqui vão entrar especificações como peso, tamanho, etc... assim não precisando da criação de várias classes distintas
        
        [Required(ErrorMessage = "Please enter the SKU")]
        [StringLength(20)]
        public override string SKU { get; set; }
        
        [Required(ErrorMessage = "please enter the Brand")]
        public override Brand brand { get; set; }
        
        [Required(ErrorMessage = "Please enter the Modality")]
        public override Modaities modalities { get; set; }
        
        [Required(ErrorMessage = "Please enter the Name")]
        [StringLength(50)]
        public override string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter the description")]
        [StringLength(200)]
        public override string description { get; set; }
        
        [Required(ErrorMessage = "Please enter the price")]
        [Range(0.01, 9999.99, ErrorMessage = "Please enter a valid price")]
        public override double price { get; set; }
    }
}