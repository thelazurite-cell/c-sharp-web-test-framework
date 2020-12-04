using System;
using Coypu;
using OpenQA.Selenium;
using TestAutomation.Framework.WebDriver.Interfaces;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    /// <summary>
    /// The block class - this represents an element that contains its value within the InnerHtml
    /// e.g. a DIV or a SPAN element.
    /// </summary>
    public class ReadonlyDomObject : DomObject,IClickable
    {
        public ReadonlyDomObject(Locator locator, Scope scope)
            : base(locator, scope)
        {
        }

        /// <summary>
        /// Gets the value for the block
        /// </summary>
        /// <exception cref="InvalidOperationException">We shouldn't try to modify a block's value</exception>
        public override string Value
        {
            get => Locate(this.Locator).Text;

            // ReSharper disable once ObjectCreationAsStatement - we're throwing an exception so we don't care
            set => new InvalidOperationException($"Shouldn't be trying to change a block's value ({value})");
        }
        
        public void Click()
        {
            Locate(this.Locator).Click();
        }
    }
}