using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationRedo{

    [TestFixture]
    public class Tests{  //: LoginTest{
        IWebDriver swagDriver;
        LoginTest logger;
        InventoryTest inventory;
        Cart2Checkout2Test carter;

        //Unit tests not able to run without constructor --> why?
        // public Tests() : base(null)
        // {
        //     //swagDriver = new ChromeDriver();
        // }

        [SetUp]
        public void Setup()
        {
            this.swagDriver = new ChromeDriver();
            logger = new LoginTest(this.swagDriver);
            inventory = new InventoryTest(this.swagDriver);
            carter = new Cart2Checkout2Test(this.swagDriver);
        }

        //[Test] --> should not be separate test, just a method for steps prior to test
        public void AccessSite()
        {
            swagDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(3000);
            Assert.That(swagDriver.Title, Is.EqualTo("Swag Labs")); 
        }

        [Test]
        public void Login()
        {
            //valid login test
            AccessSite();
            logger.ValidLoginTest();
            //invalid login test
            AccessSite();
            logger.InvalidLoginTest();
        }

        [Test]
        public void InventoryAddRemove(){
            AccessSite();
            logger.ValidLoginTest();
            //Add to cart
            inventory.AddToCart();
            inventory.RemoveFromCart();
        }

        [Test]
        public void AccessCart(){
            InventoryAddRemove();
            inventory.ValidateCartItems();
            carter.ValidInfoCheckout();
            //try with invalid info
            Thread.Sleep(3000);
            //carter.InvalidInfoCheckout();
            //inventory.ValidateCartItems();
        }

        [OneTimeTearDown]
        public void CloseSite(){
            swagDriver.Quit();
        }
    }
}