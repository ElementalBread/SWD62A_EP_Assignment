using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {
        //void CheckOut(List<Product> productsInCart);

        IQueryable<ProductViewModel> GetOrders();

        ProductViewModel GetOrder(Guid id);

        void AddProductToOrder(ProductViewModel data);

        void DeleteProductFromOrder(Guid id);
    }
}
