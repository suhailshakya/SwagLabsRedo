using OpenQA.Selenium;

namespace AutomationRedo {

    public class Cart3Checkout3Test{

        IWebDriver cart3TestDriver;
        Cart3Page3Class cart3Object;

        public Cart3Checkout3Test(IWebDriver driver){
            this.cart3TestDriver = driver;
            cart3Object = new Cart3Page3Class(this.cart3TestDriver);
        }

        public void ValidateCart3Title(){
            string titleVerifyCart3 = cart3Object.AccessCart3_PageTitle();
            Assert.That(titleVerifyCart3, Is.EqualTo("Checkout: Overview"), "Titles match on final cart page");
        }

    }
}