using System;
using System.IO;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestTask.API;

namespace TestTask
{
    [Binding]
    public class TestSetup
    {
        private static ChromeDriver c_driver;
        private static WebDriverWait c_wait;

        [BeforeTestRun]
        public static void beforeTestRun()
        {
            var chromeDriverFile = @"C:\Program Files (x86)\Google\Chrome\Application\chromedriver.exe";

            if (File.Exists(chromeDriverFile))
            {
                Console.WriteLine("ChromeDriver is found");
            }
            else
            {
                throw new Exception("ChromeDriver.exe does not exist! Please copy file to directory " + chromeDriverFile);
            }

            c_driver = new ChromeDriver("C:\\Program Files (x86)\\Google\\Chrome\\Application");
            c_driver.Navigate().GoToUrl("http://www.pinterest.com");


        }

        [BeforeScenario()]
        public static void beforeScenario()
        {
            var Automation = new Automation(c_driver);
            ScenarioContext.Current.Set<WebUser>(new WebUser(Automation));
        }

        [AfterScenario()]
        public static void afterScenario()
        {
            //c_driver.Manage().Cookies.DeleteAllCookies();
        }

        [AfterTestRun]
        public static void afterTestRun()
        {
            c_driver.Quit();
        }

    }
}
