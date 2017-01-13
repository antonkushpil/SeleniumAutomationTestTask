using TestTask.API;

namespace TestTask.Services
{
    class LoginService
    {
        public void InsertUserName(string userName)
        {
            UserApi.Instance.Automation.Login.SetUserName(userName);
        }

        public void InsertPassword(string password)
        {
            UserApi.Instance.Automation.Login.SetPassword(password);
        }

        public void EnterKeyWord(string keyWord)
        {
            UserApi.Instance.Automation.Login.EnterKeyWord(keyWord);
        }

        public bool IsLoginViewOpened()
        {
            return UserApi.Instance.Automation.Login.isLoginViewOpened();
        }

        public bool IsHomeViewOpened()
        {
            return UserApi.Instance.Automation.Login.isHomeViewOpened();
        }

        public bool IsConfirmationViewOpened()
        {
            return UserApi.Instance.Automation.Login.isConfirmationViewOpened();
        }

        public void ClickButton(string buttonName)
        {
            UserApi.Instance.Automation.Login.ClickButton(buttonName);
        }

        public void SwitchToWindow(int windowNumber)
        {
            UserApi.Instance.Automation.Login.SwitchToWindow(windowNumber);
        }
    }
}
