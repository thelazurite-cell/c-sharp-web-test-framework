using System;
using System.Linq;
using Coypu;
using OpenQA.Selenium;
using TestAutomation.Framework.ClassExtenders;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    /// <summary>
    /// Represents a page object. This could be anything displayed on a document.
    /// </summary>
    /// <typeparam name="T">The expected value type </typeparam>
    public class GenericDomObject<T>
        : ScopeDependentObject
    {
        protected GenericDomObject(Locator locator, Scope scope, bool wait = true)
            : base(scope)
        {
            this.Locator = locator;
            this.Wait = wait;
        }

        /// <summary>
        /// Checks if the page object exists
        /// </summary>
        public virtual bool Exists => Locate(this.Locator).Exists();

        /// <summary>
        /// Gets or sets the value of a page object
        /// </summary>
        public virtual T Value
        {
            get => (T)Convert.ChangeType(Locate(this.Locator).Value, typeof(T));
            set
            {
                var scope = Locate(this.Locator);
                
                if (this.Wait)
                {
                    scope.Click();
                    if (this.Wait && this.Scope is BrowserSession browser)
                    {
                        browser.WaitForAjax();
                    }
                }

                scope.FillInWith(value.ToString());
            }
        }

        public Locator Locator { get; }

        protected bool Wait { get; }
        

        public Options GetOptions() => this.Locator.Option;
    }
}