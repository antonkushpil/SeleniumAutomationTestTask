using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestTask.Views
{
    public class BaseView
    {
        protected WebDriverWait c_wait;
        protected ChromeDriver c_driver;

        public BaseView(ChromeDriver driver)
        {
            c_driver = driver;
            c_wait = new WebDriverWait(c_driver, TimeSpan.FromSeconds(15));
        }

        protected IWebElement FindElement(By by)
        {
            WaitForElementCondition(() => c_driver.FindElement(by) != null);

            return c_driver.FindElement(by);
        }

        public bool WaitForElementCondition(Func<bool> condition)
        {
            c_wait.PollingInterval = TimeSpan.FromMilliseconds(15);
            c_wait.Timeout = TimeSpan.FromMinutes(3);
            return c_wait.Until(state => condition());
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            WaitForElementCondition(() => c_driver.FindElement(by) != null);
            return c_driver.FindElements(by);
        }

        protected string this[By by]
        {
            get
            {
                return FindElement(by).Text;
            }
            set
            {
                var element = FindElement(by);

                if (value == "Enter")
                {
                    element.SendKeys(Keys.Enter);
                }
                else
                {
                    element.Clear();
                    element.SendKeys(value);
                }
            }
        }
    }
}
