using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Data.Repositories {
    public class OrdersRepository : IOrdersRepository {

        private ShoppingCartDbContext _context;
        public OrdersRepository(ShoppingCartDbContext context) {
            _context = context;
        }
        public void AddOrder(Order o, OrderDetails details) {
            _context.Orders.Add(o);
            _context.OrdersDetails.Add(details);
            _context.SaveChanges();
        }
        

        public void DeleteOrder(Guid orderId) {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid id) {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetOrders() {
            throw new NotImplementedException();
        }
    }
}
