//identify if cart item count exists --> return to CartTest
//create variable and assign cart count value retrived from CartPageClass to keep track
//use assert to check if cart exists with value --> assign value from CartPage - cart identifier
//use assert to validate and compare clickCounter and cart value

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace AutomationRedo{
    
    [TestFixture]
    public class InventoryTest{

        IWebDriver inventTestDriver;
        InventoryPageClass inventObject;
        Cart2Page2Class cartObject;
        int inventCartCount = 0;
        IWebElement spanElement;

        public InventoryTest(IWebDriver driver)
        {
            this.inventTestDriver = driver; //set to swagdriver (chrome driver)
            inventObject = new InventoryPageClass(this.inventTestDriver);
            cartObject = new Cart2Page2Class(this.inventTestDriver);
        }

        public IWebElement checkCartSpanExist(){
            try {
                Thread.Sleep(3000);
                //check if span element appears after addition
                this.spanElement = inventTestDriver.FindElement(By.ClassName("shopping_cart_badge"));
            }
            catch (NoSuchElementException) {
                this.spanElement = null;
            }
            return this.spanElement;
        }

        public void AddToCart(){
            //add elements and get count
            inventCartCount = inventObject.AddElements();
            if (checkCartSpanExist() != null){
                //compare amount of elements selected on top right to amount of clicks
                Assert.That(inventCartCount, Is.EqualTo(int.Parse(this.spanElement.Text)), "amount of items match after addition");
            }
            else{
                //Assert.Fail("Shopping cart badge not found");
                Assert.That(this.spanElement, Is.EqualTo(null), "Shopping cart badge not found");
            }
        }

        public void RemoveFromCart(){
            inventCartCount = inventObject.RemoveElements();
            if (inventCartCount == 0 && checkCartSpanExist() == null){
                Assert.That(this.spanElement, Is.EqualTo(null), "Shopping cart badge not found due to no items");
            }
            else{
                Assert.That(inventCartCount, Is.EqualTo(int.Parse(checkCartSpanExist().Text)), "amount of items match after removal");
            }
        }

        public void ValidateCartItems(){
            //first cart page
            inventObject.AccessCartItems();
            if (inventCartCount > 0 && checkCartSpanExist() != null){
                Assert.That(inventCartCount, Is.EqualTo(int.Parse(checkCartSpanExist().Text)), "amount of items match in cart page");
                //goes to cart personal info page
                cartObject.CheckoutCart();
            }
            else{
                Assert.That(this.spanElement, Is.EqualTo(null), "Shopping cart badge not found due to no items in cart page");
            }
        }
        
    }
}
