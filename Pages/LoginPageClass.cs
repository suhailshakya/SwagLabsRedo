using OpenQA.Selenium;

namespace AutomationRedo{
    public class LoginPageClass{

        IWebDriver loginDriver;

        private readonly By userNameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");

        //define constructor to initialize driver
        public LoginPageClass(IWebDriver driver){
            this.loginDriver = driver; //driver passed from UnitTest to LoginTest to here
        }

        //find username field and add input
        public void userNameFunc(string userValue){
            loginDriver.FindElement(userNameField).SendKeys(userValue);
        }

        //find password field and add input
        public void passwordFunc(string passValue){
            loginDriver.FindElement(passwordField).SendKeys(passValue);
        }

        //click login
        public void LoginFunc(){
            loginDriver.FindElement(loginButton).Click();
        }

        public void CloseAfterLogin(){
            loginDriver.Close();
        }

    }
}