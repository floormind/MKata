using MKata.Models;
using MKata.Repository.Concrete;
using MKata.Repository.Interface;
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
            IDataRepository fakeDatabaseRepository = new FakeDataRepository();
            var defaultShoppingCartItemsCount = 0;

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
    }
}