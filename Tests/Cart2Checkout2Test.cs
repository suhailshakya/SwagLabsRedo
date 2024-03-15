using OpenQA.Selenium;

namespace AutomationRedo{
    
    [TestFixture]
    public class Cart2Checkout2Test{
        //first proper cart page, with personal info fill out required

        IWebDriver cartTestDriver;
        Cart2Page2Class cartObject;

        public Cart2Checkout2Test(IWebDriver driver)
        {
            this.cartTestDriver = driver; //swagDriver -> inventDriver -> cartDriver
            cartObject = new Cart2Page2Class(this.cartTestDriver);
        }

        public void ValidInfoCheckout(){
            IWebElement textElement = cartTestDriver.FindElement(By.ClassName("title"));
            Thread.Sleep(3000);
            Assert.That(textElement.Text, Is.EqualTo("Checkout: Overview"), "strings are equal after checkout part 2");
        }

        public void InvalidInfoCheckout(){
            cartObject.ReverseCheckout();
            cartObject.InvalidInfoFillOut();
            IWebElement textElement = cartTestDriver.FindElement(By.ClassName("error-message-container error"));
            Assert.That(textElement.Text, Does.Contain("Error"), "correct error");
        }

    }
}