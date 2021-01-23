using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    /// <summary>
    /// This Class will be the model that you are going to pass on to whoever is using your classes
    /// remember: it could be someone who is paying for the service
    /// //        it could be some 3rd pary company/developer which is not trustworthy
    /// </summary>
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
    
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CategoryViewModel Category { get; set; }



    }
}
