using System.Collections.Generic;
using MKata.Helpers.Concrete;
using MKata.Helpers.Interface;
using MKata.Models;
using MKata.Repository.Concrete;
using MKata.Repository.Interface;
using Moq;
using NUnit.Framework;

namespace MKata.Test
{
    // What
    //    -> Ability to Scan PRODUCTS
    //    -> Ability to ask for Total Price of Scanned items (-> Apply discount mechanism)
    //    -> Create checkout (-> Apply discount mechanism)
    // How
    //    -> A way to hold the current list of products
    //    -> A way to hold the special offers of the products
    //    -> A Way to add scan product/products in to basket
        
    // Testing
    //    -> Create Product object
    //    -> Create a mechanism of applying the type of discount we want to apply
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void Repository_UpdateCart_Returns_Total_Of_Items_In_Cart()
        {
            //arrange
            IDataRepository fakeDatabaseRepository = new FakeDataRepository(new DefaultDiscountStrategy());

            var product = new Product()
            {
                UnitPrice = 1.00,
                SKU = "ABC"
            };
            
            //act
            var sut = fakeDatabaseRepository.UpdateCart(product);
            //assert
            Assert.AreEqual(1, sut);
        }

        [Test]
        public void Repository_Get_Total_Of_Cart_Items_Without_Discount()
        {
            //arrange
            IDataRepository fakeDatabaseRepository = new FakeDataRepository(new DefaultDiscountStrategy());

            var shoppingCard = new List<Product>()
            {
                new Product()
                {
                    UnitPrice = 5.00,
                    SKU = "A99"
                },
                new Product()
                {
                    UnitPrice = 3.00,
                    SKU = "B15"
                }
            };
            
            shoppingCard.ForEach(x => fakeDatabaseRepository.UpdateCart(x));
            
            //act

            var sut = fakeDatabaseRepository.GetTotal();
            //assert
            
            Assert.AreEqual(8.00d, sut);
        }

        [Test]
        public void Repository_Get_Total_Of_Cart_Items_With_Discount()
        {
            //arrange
            IDataRepository fakeDatabaseRepository = new FakeDataRepository(new DefaultDiscountStrategy());

            var shoppingCart = new List<Product>()
            {
                new Product()
                {
                    UnitPrice = 0.50,
                    SKU = "A99"
                },
                new Product()
                {
                    UnitPrice = 0.60,
                    SKU = "C40"
                },
                new Product()
                {
                    UnitPrice = 0.50,
                    SKU = "A99"
                },
                new Product()
                {
                    UnitPrice = 0.60,
                    SKU = "C40"
                },
                new Product()
                {
                    UnitPrice = 0.30,
                    SKU = "B15"
                },
                new Product()
                {
                    UnitPrice = 0.30,
                    SKU = "B15"
                },
                new Product()
                {
                    UnitPrice = 0.50,
                    SKU = "A99"
                },
            };
            
            shoppingCart.ForEach(x => fakeDatabaseRepository.UpdateCart(x));
            
            //act

            var sut = fakeDatabaseRepository.GetTotal();
            //assert
            
            Assert.AreEqual(2.95d, sut);
        }
    }
}