using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace ShoppingCart.Application.Services {
    public class OrdersService : IOrdersService{

        private IOrdersRepository _ordersRepo;
        private IMapper _mapper;
        public OrdersService(IOrdersRepository ordersRepo, IMapper mapper) {
            _ordersRepo = ordersRepo;
            _mapper = mapper;
        }

        public void AddOrder(OrderViewModel o, OrderDetailsViewModel d) {
            var order = _mapper.Map<Order>(o);
            var details = _mapper.Map<OrderDetails>(d);
            _ordersRepo.AddOrder(order,details);
        }

        public void DeleteOrder(Guid orderId) {
            if (_ordersRepo.GetOrder(orderId) != null)
                _ordersRepo.DeleteOrder(orderId);
        }

        public OrderViewModel GetOrder(Guid id) {
            Order order = _ordersRepo.GetOrder(id);
            var result = _mapper.Map<OrderViewModel>(order);
            return result;
        }

        public OrderDetailsViewModel GetOrderDetails(Guid id) {
            OrderDetails orderDetails = _ordersRepo.GetOrderDetails(id);
            var result = _mapper.Map<OrderDetailsViewModel>(orderDetails);
            return result;
        }

        public IQueryable<OrderViewModel> GetOrders() {
            return _ordersRepo.GetOrders().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);

        }

        public IQueryable<OrderDetailsViewModel> GetOrdersDetails() {
            return _ordersRepo.GetOrdersDetails().ProjectTo<OrderDetailsViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
