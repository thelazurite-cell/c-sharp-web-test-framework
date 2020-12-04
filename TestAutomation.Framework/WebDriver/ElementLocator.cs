using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Coypu;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace TestAutomation.Framework.WebDriver
{
    public static class ElementLocator
    {
        /// <summary>
        /// Gets or sets the Scope session
        /// </summary>
        public static Scope Scope { get; set; }

        /// <summary>
        /// Locates a single element
        /// </summary>
        /// <param name="locator">the options used to locate an element</param>
        /// <returns>an element if it could find one</returns>
        public static ElementScope Locate(Locator locator)
        {
            var result = InvokeBrowserLocator(locator);

            if (result is ElementScope scope)
            {
                return scope;
            }

            Assert.Fail($"Couldn't find '{locator.Selector}' using type '{locator.Type}'");
            return null;
        }

        /// <summary>
        /// Used to locate multiple elements matching provided criteria
        /// </summary>
        /// <param name="locator">the options used to locate elements</param>
        /// <returns>the expected elements if they could be found</returns>
        public static IEnumerable<SnapshotElementScope> LocateMultiple(Locator locator)
        {
            var result = InvokeBrowserLocator(locator, true);

            if (result is IEnumerable<SnapshotElementScope> scope)
            {
                return scope;
            }

            Assert.Fail($"Couldn't match any elements using '{locator.Selector}' with type '{locator.Type}'");
            return null;
        }

        /// <summary>
        /// Performs the lookup after using the locator options to determine the correct method to use
        /// </summary>
        /// <param name="locator">the options used to perform the lookup</param>
        /// <param name="isMultiple">determines whether we are searching for multiple elements</param>
        /// <returns>an object provided from the dynamically invoked method.</returns>
        private static object InvokeBrowserLocator(Locator locator, bool isMultiple = false)
        {
            var method = typeof(Scope)
                .GetMethods()
                .FirstOrDefault(LookupMethod(locator, isMultiple ? 3 : 2));

            var result = method?.Invoke(
                locator.Scope != null ? (Scope)locator.Scope : Scope,
                isMultiple ? new object[] { locator.Selector, null, locator.Option } : new object[] { locator.Selector, locator.Option });

            return result;
        }

        private static Func<MethodInfo, bool> LookupMethod(Locator locator, int param = 2)
        {
            return itm => itm.Name == $"Find{locator.Type}" && itm.GetParameters().Length == param;
        }
    }
}