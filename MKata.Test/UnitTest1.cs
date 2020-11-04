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
            Assert.AreEqual(false, true );
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}