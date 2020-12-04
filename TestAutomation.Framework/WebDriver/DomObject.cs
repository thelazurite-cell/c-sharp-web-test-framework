using System;
using System.Linq;
using System.Reflection;
using Coypu;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestAutomation.Framework.WebDriver.Interfaces;
using static TestAutomation.Framework.Configuration.ConfigurationSingleton;

namespace TestAutomation.Framework.WebDriver
{
    /// <summary>
    /// Represents a page object. This could be anything displayed on a document.
    /// </summary>
    public class DomObject : GenericDomObject<string>, IClickable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomObject"/> class.
        /// </summary>
        /// <param name="locator">The identifier of the page object.</param>
        /// <param name="scope">The scope this object is relevant to.</param>
        /// <param name="wait">A value indicating whether we need to wait for an ajax call after modifying the object's value.</param>
        public DomObject(Locator locator, Scope scope, bool wait = true)
            : base(locator, scope, wait)
        {
        }

        /// <summary>
        /// Click on an element.
        /// </summary>
        public virtual void Click()
        {
            var elementScope = ElementLocator.Locate(this.Locator);
            if (elementScope.Exists())
            {
                elementScope.Click();
            }
        }

        public static void WaitUntilObjectNotVisible(Locator locator)
        {
            if (!(ElementLocator.Scope is BrowserSession browser) || !(browser.Native is IWebDriver driver)) return;

            var wait = new WebDriverWait(driver,
                TimeSpan.FromSeconds(Config.FrameworkOptions.MaxExplicitWaitInSeconds));

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(InvokeCheck(locator)));
        }

        public static void TextNotToBePresentInElement(ElementScope ele, string text)
        {
            if (!(ElementLocator.Scope is BrowserSession browser) || !(browser.Native is IWebDriver driver)) return;

            var wait = new WebDriverWait(driver,
                TimeSpan.FromSeconds(Config.FrameworkOptions.MaxExplicitWaitInSeconds));
            wait.Until(TextPresentCheckReturnsTrue(ele, text));
        }

        private static Func<IWebDriver, bool> TextPresentCheckReturnsTrue(ElementScope ele, string text)
        {
            return itm =>
            {
                try
                {
                    if (ele.Exists())
                    {
                        return ele.Text != text;
                    }

                    return true;
                }
                catch (MissingHtmlException)
                {
                    return true;
                }
            };
        }

        private static By InvokeCheck(Locator locator)
        {
            return (By) typeof(By).InvokeMember(
                ConversionHelper.ByClassMethodConverter[locator.Type], BindingFlags.InvokeMethod,
                Type.DefaultBinder, null, new object[] {locator.Selector});
        }
    }
}