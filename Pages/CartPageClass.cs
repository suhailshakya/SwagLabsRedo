using OpenQA.Selenium;

namespace AutomationRedo {

    public class CartPageClass{

        IWebDriver cartDriver;
        private readonly By checkoutButton = By.Id("checkout");

        public CartPageClass(IWebDriver driver){
            this.cartDriver = driver; //same driver from unit test
        }

        public void CheckoutCart_AccessCart2(){
            cartDriver.FindElement(checkoutButton).Click();
        }
    }
}