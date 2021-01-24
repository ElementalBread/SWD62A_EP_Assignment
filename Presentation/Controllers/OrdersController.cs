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
            model.Orders = _ordersService.GetOrders();
            model.OrdersDetails = _ordersService.GetOrdersDetails();
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
                TempData["warning"] = "Product was not added. Check your details";
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Products");
        }
        [HttpPost]
        public IActionResult Checkout()
        {

            string emailOfTheUserWhoIsLoggedIn = User.Identity.Name;


            //1. get a list of products inside the ShoppingCart table belonging to the logged in user

            //2. create an order

            //3. loop inside the list brought from (1)
                 //for every product
                  // 3.1 check first the stock
                  // 3.2 deduct qty from stock
                  // 3.3 insert an order detail


            //4. remove items from the ShoppingCart table for the logged in user

            return View();
        }
    }
}
