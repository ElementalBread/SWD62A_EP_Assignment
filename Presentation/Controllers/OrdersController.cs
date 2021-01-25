using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;
using Presentation.Models;


namespace Presentation.Controllers
{
    public class OrdersController : Controller{
        private IOrdersService _ordersService;
        private IProductsService _productsService;
        private IWebHostEnvironment _env;
        public OrdersController(IOrdersService ordersService, IWebHostEnvironment env, IProductsService productsService) {
            _productsService = productsService;
            _ordersService = ordersService;
            _env = env;
        }
        public IActionResult Index() {
            dynamic model = new ExpandoObject();
            model.Products = _productsService.GetProducts();
            var Orders = _ordersService.GetOrders();
            var OrdersDetails = _ordersService.GetOrdersDetails();


            /*var orders = Orders.AsQueryable().Join(OrdersDetails,
                   Orders => Orders.Id,
                   OrdersDetails => OrdersDetails.OrderFk,
                   (order, orderDetail) =>
                       new { Date = order.DatePlaced, Price = orderDetail.Price, Quantity = orderDetail.Quantity });*/

            model.Orders = Orders;
            model.OrdersDetails = OrdersDetails;
            return View(model);
        }
       
        public IActionResult addOrder(Guid id) {
            var product = _productsService.GetProduct(id);

            CreateOrderModel model = new CreateOrderModel();
            model.Order = new OrderViewModel();
            model.Order.Id = Guid.NewGuid();
            model.Order.DatePlaced = DateTime.Now;
            model.Order.MemberEmail = User.Identity.Name;

            model.OrderDetails = new OrderDetailsViewModel();
            model.OrderDetails.Id = Guid.NewGuid();
            model.OrderDetails.Price = product.Price;
            model.OrderDetails.ProductFk = product.Id;
            model.OrderDetails.OrderFk = model.Order.Id;
            model.OrderDetails.Quantity = 1;

            try {
                _ordersService.AddOrder(model.Order, model.OrderDetails);
                TempData["feedback"] = "Order was added successfully";
                ModelState.Clear();
            } catch {
                TempData["warning"] = "Order was not added. Check your details";
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            var Orders = _ordersService.GetOrders();
            var OrdersDetails = _ordersService.GetOrdersDetails();
            string emailOfTheUserWhoIsLoggedIn = User.Identity.Name;

            foreach(var order in Orders) {
                if(order.MemberEmail == User.Identity.Name) {
                    foreach(var orderDetail in OrdersDetails) {
                        if(orderDetail.OrderFk == order.Id) {
                            deleteOrder(order.Id, orderDetail.OrderFk);
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Products");
        }

        public IActionResult deleteOrder(Guid id, Guid orderDetailId) {

            try {
                _ordersService.DeleteOrder(id, orderDetailId);
                TempData["feedback"] = "Order was added successfully";
                ModelState.Clear();
            } catch {
                TempData["warning"] = "Order was not deleted. Check your details";
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Products");
        }
    }
}
