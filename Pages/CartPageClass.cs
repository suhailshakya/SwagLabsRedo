using OpenQA.Selenium;

namespace AutomationRedo {

    public class CartPageClass{

        IWebDriver cartDriver;
        private readonly By checkoutButton = By.Id("checkout");

        public CartPageClass(IWebDriver driver){
            this.cartDriver = driver; //same driver from unit test
        }

        public void CheckoutCart(){
            cartDriver.FindElement(checkoutButton).Click();
        }

        public void InfoFillOut(){
        }
    }
}