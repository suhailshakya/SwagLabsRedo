using OpenQA.Selenium;

namespace AutomationRedo {

    public class Cart3Page3Class{

        IWebDriver cart3Driver;

        public Cart3Page3Class(IWebDriver driver){
            this.cart3Driver = driver;
        }

        public string AccessCart3_PageTitle(){
            return cart3Driver.FindElement(By.ClassName("title")).Text;
        }

    }
}