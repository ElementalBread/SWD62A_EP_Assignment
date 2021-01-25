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
    class OrdersService : IOrdersService{

        private IOrdersRepository _ordersRepo;
        private IMapper _mapper;
        public OrdersService(IOrdersRepository ordersRepo, IMapper mapper) {
            _ordersRepo = ordersRepo;
            _mapper = mapper;
        }

        public void AddProductToOrder(ProductViewModel data) {
            throw new NotImplementedException();
        }


        public void DeleteProductFromOrder(Guid id) {
            throw new NotImplementedException();
        }

        public ProductViewModel GetOrder(Guid id) {
            throw new NotImplementedException();
        }

        public IQueryable<OrderViewModel> GetOrders() {
            //ProjectTo is a way how to map from one type to the other however ONLY when you have a Queryable datatype
            return _ordersRepo.GetOrders().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);

        }

        IQueryable<ProductViewModel> IOrdersService.GetOrders() {
            throw new NotImplementedException();
        }
    }
}
