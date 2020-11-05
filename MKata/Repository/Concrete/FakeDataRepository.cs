using System.Collections.Generic;
using MKata.Helpers.Interface;
using MKata.Models;
using MKata.Repository.Interface;

namespace MKata.Repository.Concrete
{
    public class FakeDataRepository : IDataRepository
    {
        private readonly IList<Product> _shoppingCart;
        private IDiscountStrategy _discountStrategy;
        private Dictionary<string, UnitValue> _discountedProducts;

        public FakeDataRepository(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
            _shoppingCart = new List<Product>();
            _discountedProducts = new Dictionary<string, UnitValue>();
            UpdateDiscoutList();
        }

        private void UpdateDiscoutList()
        {
            _discountedProducts.Add("A99", new UnitValue() {Quantity = 3, UnitPice = 1.30});
            _discountedProducts.Add("B15", new UnitValue() {Quantity = 2, UnitPice = 0.45});
        }
        public int UpdateCart(Product product)
        {
            _shoppingCart.Add(product);
            return _shoppingCart.Count;
        }

        public double GetTotal()
        {
            var currentTotal = 0.0d;
            currentTotal = _discountStrategy.Calculate(_shoppingCart, _discountedProducts);
            return currentTotal;
        }
    }
}