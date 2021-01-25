using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces {
    public interface IOrdersRepository {
        IQueryable<Order> GetOrders();
        Order GetOrder(Guid id);

        void AddOrder(Order o, OrderDetails details);

        void DeleteOrder(Guid orderId);
    }
}
