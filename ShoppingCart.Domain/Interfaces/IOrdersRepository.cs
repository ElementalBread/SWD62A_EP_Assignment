using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces {
    public interface IOrdersRepository {
        IQueryable<Order> GetOrders();
        IQueryable<OrderDetails> GetOrdersDetails();
        Order GetOrder(Guid id);
        OrderDetails GetOrderDetails(Guid id);

        void AddOrder(Order o, OrderDetails d);

        void DeleteOrder(Guid orderId);
    }
}
