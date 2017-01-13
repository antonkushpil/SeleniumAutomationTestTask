using System.Collections.Generic;
using System.Linq;

namespace TestTask.API
{
    public class UserConfiguration
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }

    public class WebUser
    {
        public Automation Automation { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        private readonly Dictionary<string, UserConfiguration> c_descriptionToUserConfigurations;

        public WebUser(Automation automation, IEnumerable<UserConfiguration> userConfigurations = null)
        {
            Automation = automation;
            c_descriptionToUserConfigurations = GetUserConfigurationsDictionary(userConfigurations);
        }

        public WebUser()
        {
            c_descriptionToUserConfigurations = GetUserConfigurationsDictionary(null);
        }

        private Dictionary<string, UserConfiguration> GetUserConfigurationsDictionary(
            IEnumerable<UserConfiguration> userConfigurations)
        {
            if (userConfigurations == null)
            {
                userConfigurations = new[]
                {
                    new UserConfiguration() {Description = "TestUser", Password = "ab1234", UserName = "sirixandroid@gmail.com"},
                    new UserConfiguration() {Description = "EmptyPassword", Password = "", UserName = "sirixandroid@gmail.com"},
                    new UserConfiguration() {Description = "EmptyUserName", Password = "ab1234", UserName = ""},
                };
            }

            return userConfigurations.ToDictionary(p => p.Description);
        }

        public UserConfiguration GetCredentials(string description)
        {
            var user = c_descriptionToUserConfigurations[description];
            return user;
        }
    }
}
