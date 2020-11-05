using System.Collections.Generic;
using MKata.Models;
using MKata.Repository.Interface;

namespace MKata.Repository.Concrete
{
    public class FakeDataRepository : IDataRepository
    {
        private readonly IList<Product> _shoppingCart;

        public FakeDataRepository()
        {
            _shoppingCart = new List<Product>();
        }
        
        public int UpdateCart(Product product)
        {
            _shoppingCart.Add(product);
            return _shoppingCart.Count;
        }
    }
}