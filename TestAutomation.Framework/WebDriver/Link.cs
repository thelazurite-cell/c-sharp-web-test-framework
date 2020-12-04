using Coypu;
using TestAutomation.Framework.ClassExtenders;
using TestAutomation.Framework.WebDriver.Interfaces;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    /// <summary>
    /// The link class - for interacting with link classes.
    /// </summary>
    public class Link : DomObject, IClickable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        /// <param name="locator">The identifier - used to locate the link.</param>
        /// <param name="scope">The scope used, so that the link can be interacted with.</param>
        public Link(Locator locator, Scope scope, bool wait = true)
            : base(locator, scope, wait) { }

        /// <summary>
        /// Clicks the link.
        /// </summary>
        public void Click()
        {
            Locate(this.Locator).Click();
            if (this.Wait && this.Scope is BrowserSession browser)
            {
                browser.WaitForAjax();
            }
        }
    }
}