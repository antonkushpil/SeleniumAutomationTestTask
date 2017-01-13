using System;
using System.Diagnostics.Eventing.Reader;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTask.Views
{
    public class LoginView : BaseView
    {
        private static readonly By loginViewMandatoryElement = By.XPath("//div[@class='Module SignupForm homeSignupForm']");
        private static readonly By homeViewMandatoryElement = By.XPath("//input[@class='Input Module field']");
        private static readonly By confirmationViewMandatoryElement = By.XPath("//a[@data-tooltip-content='Your public profile includes name, profile picture, age range, gender, language, country and other public info']");

        private static readonly By userNameFieldXPath = By.XPath("//input[@name='email']");
        private static readonly By passwordFieldXPath = By.XPath("//input[@name='pass']");
        private static readonly By loginButtonXPath = By.XPath("//input[@name='login']");
        private static readonly By facebookButtonXPath = By.XPath("//div[@class='socialLogin']/button");
        private static readonly By okayButtonXPath = By.XPath("//button[@name='__CONFIRM__']");
        private static readonly By searchXPath = By.XPath("//input[@class='Input Module field']");

        public LoginView(ChromeDriver driver)
            : base(driver)
        {
        }

        public bool isLoginViewOpened()
        {
            return FindElement(loginViewMandatoryElement) != null;
        }

        public bool isHomeViewOpened()
        {
            return FindElement(homeViewMandatoryElement) != null;
        }

        public bool isConfirmationViewOpened()
        {
            return FindElement(confirmationViewMandatoryElement) != null;
        }

        public void SetUserName(string userName)
        {
            this[userNameFieldXPath] = userName;
        }

        public void SetPassword(string password)
        {
            this[passwordFieldXPath] = password;
        }

        public void EnterKeyWord(string keyword)
        {
            this[searchXPath] = keyword;
        }

        public void ClickButton(string buttonName)
        {
            var buttonXPath = getButtonXPath(buttonName);
            FindElement(buttonXPath).Click();
        }

        private By getButtonXPath(string buttonName)
        {
            switch (buttonName)
            {
                case "LoginWithFacebook":
                    return facebookButtonXPath;
                case "Login":
                    return loginButtonXPath;
                case "Okay":
                    return okayButtonXPath;

                default:
                    throw new Exception("Button name is not found");
            }
        }

        public void SwitchToWindow(int windowNumber)
        {
            var window = c_driver.WindowHandles[windowNumber - 1];
            Console.WriteLine("My window: " + window);
            c_driver.SwitchTo().Window(window);
        }

    }
}
