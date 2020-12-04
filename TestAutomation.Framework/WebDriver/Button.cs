using System;
using Coypu;
using TestAutomation.Framework.WebDriver.Interfaces;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    /// <summary>
    /// The button class - used for interactions with a Button Element
    /// </summary>
    public class Button : DomObject, IClickable
    {
        public Button(Locator locator, Scope scope)
            : base(locator, scope)
        {
        }

        /// <summary>
        /// Triggers if a <see cref="Button"/> has been clicked;
        /// </summary>
        public EventHandler OnClick { get; set; }

        /// <summary>
        /// Clicks on the button
        /// </summary>
        public void Click()
        {
            Locate(this.Locator).Click();

            if (this.Wait)
            {
                
            }

            this.OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}