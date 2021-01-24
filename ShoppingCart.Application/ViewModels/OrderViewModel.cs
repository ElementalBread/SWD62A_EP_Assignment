using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Application.ViewModels {
    public class OrderViewModel {
        public Guid Id { get; set; }
        public string MemberEmail { get; set; }
        public DateTime DatePlaced { get; set; }

    }
}
