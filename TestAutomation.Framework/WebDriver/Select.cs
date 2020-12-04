using System;
using System.Collections.Generic;
using Coypu;
using OpenQA.Selenium;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    /// <summary>
    /// The select class - for interacting with a drop-down/combobox
    /// </summary>
    public class Select : DomObject
    {
        public Select(Locator locator, Scope scope)
            : base(locator, scope)
        {
        }

        public EventHandler OnValueChanged { get; set; }

        /// <summary>
        /// Gets or sets the selected value of a drop-down/combobox
        /// </summary>
        public override string Value
        {
            get => Locate(this.Locator).SelectedOption;
            set
            {
                Locate(this.Locator).SelectOption(value);
                this.OnValueChanged?.Invoke(value, EventArgs.Empty);
            }
        }
    }
}