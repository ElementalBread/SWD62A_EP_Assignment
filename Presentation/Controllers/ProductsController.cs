using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;


namespace Presentation.Controllers
{
  //  [Authorize(Roles ="Admin")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        public ProductsController(IProductsService productsService,
            ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }

        /// <summary>
        /// Products Catalogue
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //IQueryable
            //IEnumerable
            //List >>>> IEnumerable >>> IQueryable
            
            var list = _productsService.GetProducts();
            
            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            var myProduct = _productsService.GetProduct(id);

            return View(myProduct);

        }

        [HttpGet] //the get method which will load the page with blank fields
        [Authorize(Roles ="Admin")] //Authorize vs Authorize(Roles="Admin") 
                                    //Authorize authorizes anyone who is logged in, Authorize(Roles="Admin")  authorizes only admins
        public IActionResult Create()
        {
            var catList = _categoriesService.GetCategories();

         //   ViewBag.Categories = catList;

            CreateProductModel model = new CreateProductModel();
            model.Categories = catList.ToList();


            return View(model); //model => ProductViewModel
        }

        [HttpPost] //the post method is called when the user clicks on the submit button
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateProductModel data, IFormFile file) //Postman, Burp, Zap, Fiddler
        {
            //validation

            //if(data.Name == "")
            //{
            //    ViewData["Warning"] = "Name cannot be left empty";
            //    return View();
            //}


            try
            {
                if(file != null)
                {
                    if(file.Length > 0)
                    {
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(file.FileName);
                        string absolutePath = _env.WebRootPath + @"\Images\";

                        using (var stream = System.IO.File.Create(absolutePath + newFilename))
                        {
                            file.CopyTo(stream);
                        }
                        data.Product.ImageUrl = @"\Images\" + newFilename; //relative Path
                    }
                }
                _productsService.AddProduct(data.Product);
                ViewData["feedback"] = "Product was added successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                //log errors
                ViewData["warning"] = "Product was not added. Check your details";

                //i want to redirect the user to a common page (when there is an error)
                //TempData["error"] = "this is a test error";
                return RedirectToAction("Error", "Home");
            }

            CreateProductModel model = new CreateProductModel();
            model.Categories = _categoriesService.GetCategories().ToList();

            return View(model);
        }


        public IActionResult Delete(Guid id)
        {
            _productsService.DeleteProduct(id);
            TempData["feedback"] = "Product was deleted successfully"; //change wherever we are using ViewData to use TempData data
            return RedirectToAction("Index");
        }


    }
}
