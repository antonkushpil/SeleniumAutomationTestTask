using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestTask.API;
using TestTask.Services;

namespace TestTask.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly LoginService loginService;

        public LoginSteps()
        {
            loginService = new LoginService();
        }

        private void InsertLoginCredentials(string userName, string password)
        {
            loginService.InsertUserName(userName);
            loginService.InsertPassword(password);
        }

        [Given(@"I am on (Login|Home|Confirmation) page")]
        [When(@"I am on (Login|Home|Confirmation) page")]
        [Then(@"I am on (Login|Home|Confirmation) page")]
        public void GivenIAmOnLoginPage(string pageName)
        {
            switch (pageName)
            {
                case "Login":
                    Assert.IsTrue(loginService.IsLoginViewOpened(), "Login page is not opened");
                    break;
                case "Home":
                    Assert.IsTrue(loginService.IsHomeViewOpened(), "Home page is not opened");
                    break;
                case "Confirmation":
                    Assert.IsTrue(loginService.IsConfirmationViewOpened(), "Confirmation page is not opened");
                    break;

                default:
                    throw new Exception("Incorrect page name");
            }
        }

        [Given(@"I click (.*) button")]
        [When(@"I click (.*) button")]
        public void GivenIClickLoginButton(string buttonName)
        {
            loginService.ClickButton(buttonName);
        }

        [When(@"I switch to (.*) window")]
        public void WhenISwitchToWindow(int windowNumber)
        {
            loginService.SwitchToWindow(windowNumber);
        }

        [When(@"I login under (.*) account")]
        public void WhenILoginUnderTestUserAccount(string accountName)
        {
            var user = new WebUser().GetCredentials(accountName);
            InsertLoginCredentials(user.UserName, user.Password);
        }

        [When(@"I enter (.*) in search field")]
        [Given(@"I enter (.*) in search field")]
        public void GivenIEnterInSearchField(string keyWord)
        {
            loginService.EnterKeyWord(keyWord);
        }


        [Then(@"I see (.*) message")]
        public void ThenISeeMessage(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see (.*)")]
        public void ThenISeeNothingHappens(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }



    }
}
