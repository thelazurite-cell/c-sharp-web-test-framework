using Coypu;
using TestAutomation.Framework.ClassExtenders;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    /// <summary>
    /// The checkbox class - for interacting with checkbox objects.
    /// </summary>
    public class CheckBox : GenericDomObject<bool>
    {
        public CheckBox(Locator locator, Scope scope, bool wait = true)
            : base(locator, scope, wait) { }

        /// <summary>
        /// Gets or sets the value for a checkbox.
        /// </summary>
        public override bool Value
        {
            get => Locate(this.Locator).Selected;
            set
            {
                if (this.Wait)
                {
                    Locate(this.Locator).Click();
                    if (this.Scope is BrowserSession browser)
                    {
                        browser.WaitForAjax();
                    }
                }

                if (value)
                {
                    this.Check();
                }
                else
                {
                    this.Uncheck();
                }
            }
        }

        /// <summary>
        /// Selects the checkbox
        /// </summary>
        private void Check()
        {
            Locate(this.Locator).Check();
        }

        /// <summary>
        /// deselects the checkbox.
        /// </summary>
        private void Uncheck()
        {
            Locate(this.Locator).Uncheck();
        }
    }
}