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
            var order = GetOrder(orderId);
            var orderDetails = GetOrderDetails(orderId);
            _context.Orders.Remove(order);
            _context.OrdersDetails.Remove(orderDetails);
            _context.SaveChanges();
        }

        public Order GetOrder(Guid id) {
            return _context.Orders.SingleOrDefault(x => x.Id == id);
        }

        public OrderDetails GetOrderDetails(Guid id) {
            return _context.OrdersDetails.SingleOrDefault(x => x.OrderFk == id);
        }

        public IQueryable<Order> GetOrders() {
            return _context.Orders;
        }

        public IQueryable<OrderDetails> GetOrdersDetails() {
            return _context.OrdersDetails;
        }
    }
}
