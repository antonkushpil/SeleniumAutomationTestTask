using OpenQA.Selenium.Chrome;
using TestTask.Views;

namespace TestTask.API
{
    public class Automation
    {
        private readonly ChromeDriver c_driver;
        public LoginView Login { get; private set; }

        public Automation(ChromeDriver driver)
        {
            c_driver = driver;
            Login = new LoginView(driver);
        }
    
    }
}
