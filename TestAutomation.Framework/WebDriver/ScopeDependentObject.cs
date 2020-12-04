using Coypu;

namespace TestAutomation.Framework.WebDriver
{
    /// <summary>
    /// The ScopeDependentObject class - used by objects that require a scope session.
    /// </summary>
    public abstract class ScopeDependentObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeDependentObject"/> class.
        /// </summary>
        /// <param name="scope">The scope that is relevant to this session.</param>
        protected ScopeDependentObject(Scope scope)
        {
            this.Scope = scope;
        }

        /// <summary>
        /// Gets the Scope.
        /// </summary>
        protected Scope Scope { get; }
    }
}