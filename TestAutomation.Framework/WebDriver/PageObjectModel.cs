using System;
using System.Linq;
using Coypu;
using Coypu.NUnit.Matchers;
using NUnit.Framework.Constraints;
using TestAutomation.Framework.ClassExtenders;

namespace TestAutomation.Framework.WebDriver
{
    /// <summary>
    /// The page object model is used to describe a part of, or a whole webpage.
    /// </summary>
    public abstract class PageObjectModel : ScopeDependentObject
    {
        protected PageObjectModel(Scope scope)
            : base(scope) { }

        /// <summary>
        /// Gets a value determining where the model is located.
        /// </summary>
        protected abstract string ModelLocation { get; }

        /// <summary>
        /// Determines whether the model contains the provided text
        /// </summary>
        /// <param name="text">The text to check</param>
        /// <returns>A boolean value determining whether the model contains the requested value</returns>
        public bool Has(string text)
        {
            return this.Scope.HasContent(text);
        }

        /// <summary>
        /// Goes to the specified location, by default it will go to the model's location.
        /// </summary>
        /// <param name="location">The location to visit</param>
        public virtual void Visit(string location = null)
        {
            if (this.Scope is BrowserSession browser)
            {
                browser.Visit(location ?? this.ModelLocation);
            }
        }

        /// <summary>
        /// Waits for an action to occur within the scope.
        /// </summary>
        public void Wait()
        {
            if (this.Scope is BrowserSession browser)
            {
                browser.WaitForAjax();
            }
        }

        public virtual bool OnPage()
        {
            var splitByQuery = this.Scope.Location.ToString().Split('?');
            return splitByQuery.FirstOrDefault()?.EndsWith(this.ModelLocation) ?? this.Scope.Location.ToString().EndsWith(this.ModelLocation);
        }

        protected bool Has(string cssSelector, string text, Options options = null)
        {
            var constraint = new HasCssMatcher(cssSelector, text, options ?? Options.FirstPreferExact);
            var res = constraint.ApplyTo(this.Scope);
            return res.Status == ConstraintStatus.Success;
        }
    }
}