//ask Romi --> check if possible to return length of list of items and select add button randomly

//identify all add and remove buttons
//create variable - clickCounter - to count adds and removes
//create add and remove functions --> return clickCounter

using OpenQA.Selenium;

namespace AutomationRedo {

    public class InventoryPageClass{

        IWebDriver inventDriver;
        private int clickCounter = 0;

        private readonly By addBikeButton = By.Id("add-to-cart-sauce-labs-bike-light");
        private readonly By addBackPackButton = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
        private readonly By addFleeceButton = By.Id("add-to-cart-sauce-labs-fleece-jacket");
        //ask ROMI -- if there is a dynamic id, how to handle this? example line 20-21 --> contains?
        private readonly By removeBikeButton = By.Id("remove-sauce-labs-bike-light");
        //private readonly By removeBackPackButton = By.Id("remove-to-cart-sauce-labs-bolt-t-shirt");
        private readonly By removeFleeceButton = By.Id("remove-sauce-labs-bolt-t-shirt");
        private readonly By cartLink = By.ClassName("shopping_cart_link");

        public InventoryPageClass(IWebDriver driver){
            this.inventDriver = driver;
        }

        public int AddElements(){
            //add all three
            inventDriver.FindElement(addBikeButton).Click();
            inventDriver.FindElement(addBackPackButton).Click();
            inventDriver.FindElement(addFleeceButton).Click();
            Thread.Sleep(3000);
            return clickCounter += 3;
        }

        public int RemoveElements(){
            //remove
            inventDriver.FindElement(removeBikeButton).Click();
            inventDriver.FindElement(removeFleeceButton).Click();
            return clickCounter -= 2;
        }

        public void AccessCartItems(){
            //goes to cart first page
            inventDriver.FindElement(cartLink).Click();
        }
    }

}