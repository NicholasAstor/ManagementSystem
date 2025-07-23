using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Footwear : Item
    {
        [Required(ErrorMessage = " Please enter the size ")]
        [Range(30, 48, ErrorMessage = " Please enter a valid size " )]
        public byte Size { get; set; }
        
        [Required(ErrorMessage = " Please enter the type")]
        public Type Type { get; set; } // Tipo de tenis
        
        [Required(ErrorMessage = "Please enter the SKU")]
        [StringLength(20)]
        public override string SKU { get; set; }
        
        [Required(ErrorMessage = " Please enter the brand")]
        public override Brand brand { get; set; }
        
        [Required(ErrorMessage = " Please enter the Modality")]
        public override Modalities Modalities { get; set; }
        
        [Required(ErrorMessage = " Please enter the Name")]
        [StringLength(50)]
        public override string Name { get; set; }
        
        [Required(ErrorMessage = "Please entrer the description")]
        [StringLength(200)]
        public override string Description { get; set; }
        
        [Required(ErrorMessge = "Please enter the Price")]
        [Range(0.01, 9999.99, ErrorMessage = "Please enter a valid price")]
        public override double Price { get; set; }
    }
}