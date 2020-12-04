using System;
using System.Collections.Generic;
using Coypu;
using OpenQA.Selenium;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;

    public enum LocatorType
    {
        /// <summary>
        /// Locate an element by its Identifier
        /// </summary>
        Id,

        /// <summary>
        /// Locate an element by its CSS Selector
        /// </summary>
        Css,

        /// <summary>
        /// Locate Multiple elements using a CSS Selector
        /// </summary>
        AllCss,

        /// <summary>
        /// Find a button by its contents
        /// </summary>
        Button,

        /// <summary>
        /// Find a link by its contents. 
        /// </summary>
        Link,

        /// <summary>
        /// Find a field 
        /// </summary>
        Field,

        /// <summary>
        /// Find a fieldset by its legend.
        /// </summary>
        Fieldset,

        /// <summary>
        /// Find a frame, or IFrame.
        /// </summary>
        Frame,

        /// <summary>
        /// Find an element using an XPath Query.
        /// </summary>
        XPath,

        /// <summary>
        /// Find all elements matching an XPath Query. 
        /// </summary>
        AllXPath
    }

    public static class ConversionHelper
    {
        public static Dictionary<LocatorType, string> ByClassMethodConverter = new Dictionary<LocatorType, string>()
        {
            [LocatorType.Id] = "Id",
            [LocatorType.Css] = "CssSelector",
            [LocatorType.Link] = "LinkText",
            [LocatorType.XPath] = "XPath",
            [LocatorType.AllCss] = "ClassName"
        };
    }
}