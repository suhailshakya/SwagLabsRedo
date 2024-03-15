using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace AutomationRedo{
    
    [TestFixture]
    public class LoginTest{

        IWebDriver LoginTestDriver;
        LoginPageClass loginObject;

        public LoginTest(IWebDriver driver) //: base(null)
        {
            this.LoginTestDriver = driver; //set to swagdriver (chrome driver)
            loginObject = new LoginPageClass(this.LoginTestDriver);
        }

        // [SetUp]
        // public void Setup()
        // {
        //     this.testDriver = new ChromeDriver();
        //     loginObject = new LoginPageClass(this.testDriver);
        // }

        //[Test]
        public void ValidLoginTest(){
            //find elements and operate through LoginPageClass
            loginObject.userNameFunc("standard_user");
            loginObject.passwordFunc("secret_sauce");
            loginObject.LoginFunc();

            IWebElement textElement = LoginTestDriver.FindElement(By.ClassName("title"));
            Thread.Sleep(3000);

            //verify if the login button redirects to the correct page by comparing Products to textElement value
            Assert.That(textElement.Text, Is.EqualTo("Products"), "strings are equal");
        }

        //[Test]
        public void InvalidLoginTest(){
            loginObject.userNameFunc("wrong_user");
            loginObject.passwordFunc("secret_sauce");
            loginObject.LoginFunc();

            IReadOnlyCollection<IWebElement> errorElements = LoginTestDriver.FindElements(By.XPath("//*[contains(@class,'error-message')]"));
            //IWebElement textElement = testDriver.FindElement(By.ClassName("error-message-container error"));
            Thread.Sleep(3000);

            //iterate through errorElements and filter by getting the class name and check if it contains error-message
            IEnumerable<IWebElement> errorMessages = errorElements.Where(error => error.GetAttribute("class").Contains("error-message"));
            //check if errorElement message shows up
            Assert.That(errorElements.First().Text, Does.Contain("sadface"), "correct error");
        }

        //[TearDown]
        public void CloseSite(){
            LoginTestDriver.Close();
        }

    }
}