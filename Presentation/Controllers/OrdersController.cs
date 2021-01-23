using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class OrdersController : Controller
    {
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
