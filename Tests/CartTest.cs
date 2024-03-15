using OpenQA.Selenium;

namespace AutomationRedo{
    
    [TestFixture]
    public class CartTest{
        //first proper cart page

        IWebDriver cartTestDriver;
        CartPageClass cartObject;
        Cart2Page2Class cart2Object;

        public CartTest(IWebDriver driver)
        {
            this.cartTestDriver = driver; //swagDriver -> inventDriver -> cartDriver
            cartObject = new CartPageClass(this.cartTestDriver);
            cart2Object = new Cart2Page2Class(this.cartTestDriver);
        }

        public void AccessCart2(){
            cartObject.CheckoutCart_AccessCart2();
            //checking for title
            string cart2Verify = cart2Object.AccessCart2_PageTitle();
            Assert.That(cart2Verify, Is.EqualTo("Checkout: Your Information"), "Cart Page 2 valid access");
        }
        
    }
}