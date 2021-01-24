using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class DomainToViewModelProfile: Profile
    {
        public DomainToViewModelProfile()
        {
            //Product >>>> ProductViewModel
            //since our properties in both classes are called the same way
            CreateMap<Product, ProductViewModel>();
            //if they were called differently
            //CreateMap<Product, ProductViewModel>().ForMember(dest=>dest.Description, src=>src.MapFrom(x=>x.Description)); 
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderDetails, OrderDetailsViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Member, MemberViewModel>();
        }
    }
}
