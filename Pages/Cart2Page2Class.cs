using OpenQA.Selenium;

namespace AutomationRedo {

    public class Cart2Page2Class{

        IWebDriver cartDriver;
        //private readonly By checkoutButton = By.Id("checkout");
        private readonly By firstName = By.Id("first-name");
        private readonly By lastName = By.Id("last-name");
        private readonly By postal = By.Id("postal-code");
        private readonly By continueButt = By.Id("continue");
        private readonly By goBack = By.Id("cancel");

        public Cart2Page2Class(IWebDriver driver){
            this.cartDriver = driver; //same driver from unit test
        }

        public string AccessCart2_PageTitle(){
            return cartDriver.FindElement(By.ClassName("title")).Text;
        }

        public void CheckoutCart2_AccessCart3(){
            cartDriver.FindElement(continueButt).Click();
        }

        public void InfoFillOut(){
            cartDriver.FindElement(firstName).SendKeys("Itachi");
            cartDriver.FindElement(lastName).SendKeys("Uchiha");
            cartDriver.FindElement(postal).SendKeys("Konoha");
            //cartDriver.FindElement(continueButt).Click();
        }

        public void InvalidInfoFillOut(){
            cartDriver.FindElement(firstName).SendKeys("Danzo");
            cartDriver.FindElement(lastName).SendKeys("");
            cartDriver.FindElement(postal).SendKeys("Konoha");
            cartDriver.FindElement(continueButt).Click();
        }

        public void ReverseCheckout(){
            cartDriver.FindElement(goBack).Click();
        }

    }
}
