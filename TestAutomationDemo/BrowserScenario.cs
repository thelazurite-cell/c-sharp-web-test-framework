using System;
using System.Collections.Generic;
using Coypu;
using Coypu.Drivers;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomation.Framework.Configuration;
using TestAutomation.Framework.WebDriver;
using static TestAutomation.Framework.Configuration.ConfigurationSingleton;

namespace TestAutomationDemo
{
    [Binding]
    [Scope(Tag = "BrowserTest")]
    public class BrowserScenario
    {
        public static BrowserSession BrowserSession { get; set; }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            var sessionConfig = new SessionConfiguration()
            {
                Port = Config.FrameworkOptions.Port,
                SSL = Config.FrameworkOptions.Ssl,
                Driver = Type.GetType("Coypu.Drivers.Selenium.SeleniumWebDriver, Coypu"),
                Browser = Browser.Parse(Config.FrameworkOptions.Browser),
                
            };
            BrowserSession = new BrowserSession(sessionConfig);
            BrowserSession.MaximiseWindow();
            ElementLocator.Scope = BrowserSession;
        }
        
        /// <summary>
        /// After running a scenario, clean up.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            BrowserSession.Dispose();
        }
        
        
        [BeforeFeature]
        public static void ReadFeatureTags(FeatureContext featureContext)
        {
            var tags = featureContext.FeatureInfo.Tags;
            var title = featureContext.FeatureInfo.Title;

            ReadTestRunTags(title, tags);
        }
        
        private static void ReadTestRunTags(string title, IEnumerable<string> tags)
        {
            foreach (var tag in tags)
            {
                PerformShouldRunCheck(title, tag);
            }
        }

        private static void PerformShouldRunCheck(string title, string tag)
        {
            var notOp = tag.StartsWith("!");
            foreach (var testItem in Config.TestCategories)
            {
                // check if matching tag with or without Not operator
                if (!string.Equals(notOp ? $"!{testItem.Category}" : testItem.Category, tag, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                DetermineIfTestShouldBeIgnored(title, notOp, testItem);

                break;
            }
        }

        private static void DetermineIfTestShouldBeIgnored(string title, bool notOp, TestCategory testItem)
        {
            var shouldSkip = notOp ? testItem.ShouldRun : !testItem.ShouldRun;
            if (!shouldSkip) return;
            var because = notOp ? "this test only needs to run when the functionality described is not supported" : testItem.Because;
            Assert.Ignore($"{title} was ignored because {because}. See {testItem.Category} in {FileName}");
        }
    }
}