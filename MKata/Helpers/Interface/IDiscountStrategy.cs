using System.Collections.Generic;
using MKata.Models;

namespace MKata.Helpers.Interface
{
    public interface IDiscountStrategy
    {
        double Calculate(IList<Product> cartItems, Dictionary<string, UnitValue> discounted);
    }
}