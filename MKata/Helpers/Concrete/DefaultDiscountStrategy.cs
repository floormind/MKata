using System;
using System.Collections.Generic;
using System.Linq;
using MKata.Helpers.Interface;
using MKata.Models;

namespace MKata.Helpers.Concrete
{
    public class DefaultDiscountStrategy : IDiscountStrategy
    {
        public double Calculate(IList<Product> cartItems, Dictionary<string, UnitValue> discounted)
        {
            var total = 0d;
            var distinctCartValues = cartItems.Select(x => x.SKU).Distinct();
            
            foreach (var distinctCartItem in distinctCartValues)
            {
                var cartProductPrice = cartItems.First(x => x.SKU.Equals(distinctCartItem)).UnitPrice;
                var amountAppeared = cartItems.Count(x => x.SKU.Equals(distinctCartItem));
                if (discounted.ContainsKey(distinctCartItem))
                {
                    var discountedProduct = discounted[distinctCartItem];
                    
                    int remainder = 0;
                    var qualifiedForDiscount = Math.DivRem(amountAppeared, discountedProduct.Quantity, out remainder);
                    if (qualifiedForDiscount != 0)
                    {
                        total += qualifiedForDiscount * discountedProduct.UnitPice;
                    }

                    total += remainder * cartProductPrice;
                }
                else
                {
                    total += amountAppeared * cartProductPrice;
                }
            }
            return total;
        }
    }
}