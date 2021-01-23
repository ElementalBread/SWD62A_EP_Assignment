using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productRepo;
        private IMapper _mapper;
        public ProductsService(IProductsRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }


        public IQueryable<ProductViewModel> GetProducts()
        {
            //Product >> ProductViewModel
            //ProjectTo is a way how to map from one type to the other however ONLY when you have a Queryable datatype
            return _productRepo.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);


            //converting from Product into ProductViewModel
            /*var list = from p in _productRepo.GetProducts()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Price = p.Price,
                           Description = p.Description,
                           ImageUrl = p.ImageUrl,
                           Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name }
                       };

            return list; */
        }

        public ProductViewModel GetProduct(Guid id)
        {
            //Product >> ProductViewModel
            Product product = _productRepo.GetProduct(id);
            var resultingProductViewModel = _mapper.Map<ProductViewModel>(product);
            return resultingProductViewModel;

            //return _mapper.Map<ProductViewModel>(_productRepo.GetProduct(id));


            /* ProductViewModel myViewModel = new ProductViewModel();
             var productFromDb = _productRepo.GetProduct(id);

             myViewModel.Description = productFromDb.Description;
             myViewModel.Id = productFromDb.Id;
             myViewModel.ImageUrl = productFromDb.ImageUrl;
             myViewModel.Name = productFromDb.Name;
             myViewModel.Price = productFromDb.Price;
             myViewModel.Category = new CategoryViewModel();
             myViewModel.Category.Id = productFromDb.Category.Id; //NullReferenceException --> a property is still null!!
             myViewModel.Category.Name = productFromDb.Category.Name;

             return myViewModel;
            */
        }

        public void AddProduct(ProductViewModel data)
        {
            //AutoMapper (NuGet Package)

            //ProductViewModel ====> Product

            var p = _mapper.Map<Product>(data);
            p.Category = null;
            _productRepo.AddProduct(p);


           /* Product p = new Product();
            p.Description = data.Description;
            p.ImageUrl = data.ImageUrl;
            p.Name = data.Name;
            p.Price = data.Price;
            p.CategoryId = data.Category.Id;

            _productRepo.AddProduct(p);
           */


        }

        public void DeleteProduct(Guid id)
        {
            if(_productRepo.GetProduct(id) != null)
                _productRepo.DeleteProduct(id);
        }
    }
}
