using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

//code first
namespace ShoppingCart.Domain.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage ="Please input name")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
     
        [Required]
        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

     /*   public int Stock { get; set; }
        public double WholesalePrice { get; set; }
        public string Supplier { get; set; }
       */  
    }
}
