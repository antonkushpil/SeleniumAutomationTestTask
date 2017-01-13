using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestTask.API
{
    public static class UserApi
    {
        public static WebUser Instance { get { return ScenarioContext.Current.Get<WebUser>(); } }
    }
}
