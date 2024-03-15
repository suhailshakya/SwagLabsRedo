using OpenQA.Selenium;

namespace AutomationRedo{
    
    [TestFixture]
    public class CartTest{
        //first proper cart page, with personal info fill out required

        IWebDriver cartTestDriver;
        Cart2Page2Class cartObject;

        public CartTest(IWebDriver driver)
        {
            this.cartTestDriver = driver; //swagDriver -> inventDriver -> cartDriver
            cartObject = new Cart2Page2Class(this.cartTestDriver);
        }

        
    }
}