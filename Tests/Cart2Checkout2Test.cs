using OpenQA.Selenium;

namespace AutomationRedo{
    
    [TestFixture]
    public class Cart2Checkout2Test{
        //first proper cart page, with personal info fill out required

        IWebDriver cart2TestDriver;
        Cart2Page2Class cart2Object;
        Cart3Page3Class cart3Object;

        public Cart2Checkout2Test(IWebDriver driver)
        {
            this.cart2TestDriver = driver; //swagDriver -> inventDriver -> cartDriver
            cart2Object = new Cart2Page2Class(this.cart2TestDriver);
            cart3Object = new Cart3Page3Class(this.cart2TestDriver);
        }

        public void ValidInfoCheckout_AccessCart3(){
            cart2Object.InfoFillOut();
            cart2Object.CheckoutCart2_AccessCart3();
        }

        public void InvalidInfoCheckout(){
            cart2Object.ReverseCheckout();
            cart2Object.InvalidInfoFillOut();
            IWebElement textElement = cart2TestDriver.FindElement(By.ClassName("error-message-container error"));
            Assert.That(textElement.Text, Does.Contain("Error"), "correct error");
        }

    }
}