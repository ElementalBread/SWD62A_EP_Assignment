using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Application.ViewModels;

namespace Presentation.Models {


    public class CreateOrderModel {
        public OrderViewModel Order { get; set; }
        public OrderDetailsViewModel OrderDetails { get; set; }

    }

        public class ListOrderModel {
            public List<OrderViewModel> Orders { get; set; }
            public List<OrderDetailsViewModel> OrdersDetails { get; set; }
        }
    
}
