using System;
using System.Diagnostics;
using Coypu;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomation.Framework.Configuration;
using static TestAutomation.Framework.Configuration.ConfigurationSingleton;

namespace TestAutomation.Framework.ClassExtenders
{
    public static class BrowserScopeExtensions
    {
        public static bool WaitForAjax(this BrowserSession scope)
        {
            if (!(scope.Driver.Native is IWebDriver driver)) return false;
            var waitLength = Config.FrameworkOptions.MaxAjaxCallWaitInSeconds;
            var wait = new WebDriverWait(driver,
                TimeSpan.FromSeconds(waitLength)) {PollingInterval = TimeSpan.FromSeconds(1)};
            var timer = new Stopwatch();
            timer.Start();
            var res = PerformWait(wait, timer, waitLength);
            timer.Stop();
            return res;
        }

        private static bool PerformWait(WebDriverWait wait, Stopwatch timer, int waitLength)
        {
            return wait.Until(session =>
            {
                if (!(bool) ((IJavaScriptExecutor) session).ExecuteScript("return jQuery.active === 1"))
                    return (double) timer.ElapsedMilliseconds > waitLength;
                timer.Restart();
                return false;
            });
        }
    }
}