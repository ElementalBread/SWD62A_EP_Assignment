using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {
        IQueryable<OrderViewModel> GetOrders();
        IQueryable<OrderDetailsViewModel> GetOrdersDetails();
        OrderViewModel GetOrder(Guid id);
        OrderDetailsViewModel GetOrderDetails(Guid id);

        void AddOrder(OrderViewModel o, OrderDetailsViewModel d);

        void DeleteOrder(Guid orderId, Guid orderDetailId);
    }
}
