using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumTesting.support
{
    class EnvironmentProvider
    {
        private static Dictionary<string, string> envs = new Dictionary<string, string>();
        static EnvironmentProvider()
        {
            envs.Add("development", "http://www.ubs.com");
            envs.Add("production", "http://www.ubs.com");
        }

        public static string getEnvironment(string env)
        {
            return envs.TryGetValue(env, out string environment) ? environment : "http://www.ubs.com";
        }
    }
}
