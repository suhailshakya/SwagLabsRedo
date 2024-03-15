using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationRedo{

    [TestFixture]
    public class Tests{  //: LoginTest{
        IWebDriver swagDriver;
        LoginTest logger;
        InventoryTest inventory;
        CartTest cart1;
        Cart2Checkout2Test cart2;
        Cart3Checkout3Test cart3;

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
            cart1 = new CartTest(this.swagDriver);
            cart2 = new Cart2Checkout2Test(this.swagDriver);
            cart3 = new Cart3Checkout3Test(this.swagDriver);
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
        public void AccessCartCheckout(){
            InventoryAddRemove();
            //check access to cart 1
            inventory.AccessCart();
            //check access to cart 2
            cart1.AccessCart2();
            //check access to cart 3 with valid info
            cart2.ValidInfoCheckout_AccessCart3();
            Thread.Sleep(3000);
            cart3.ValidateCart3Title();
            Thread.Sleep(3000);
            //try with invalid info
            //carter.InvalidInfoCheckout();
            
        }

        [OneTimeTearDown]
        public void CloseSite(){
            swagDriver.Quit();
        }
    }
}