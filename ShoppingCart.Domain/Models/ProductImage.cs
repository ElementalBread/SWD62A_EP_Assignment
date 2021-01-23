using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
  /* public class ProductImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
    }
  */

    //0. ShoppingCartDbContext -  you need to add a DbSet<ProductImage> ProductImages
    //1. compile
    //2. add-migration "addingproductimage" -Context ShoppingCartDbContext
    //3. update-database -Context ShoppingCartDbContext
}
