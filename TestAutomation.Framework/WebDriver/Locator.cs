using Coypu;

namespace TestAutomation.Framework.WebDriver
{
    public class Locator
    {
        private readonly ElementScope scope;
        private string selector;
        private LocatorType type;
        private Options option;

        /// <summary>
        /// Creates a new instance of the <see cref="Locator"/> class.
        /// </summary>
        /// <param name="selector">the selector query</param>
        /// <param name="type">the type of query being made. Defaults to ID.</param>
        public Locator(string selector, LocatorType type = LocatorType.Id, Options option = null, ElementScope scope = null)
        {
            this.selector = selector;
            this.type = type;
            this.scope = scope;
            this.option = option ?? Options.Exact;
        }

        public string Selector
        {
            get => this.selector;
            set => this.selector = value;
        }

        public LocatorType Type
        {
            get => this.type;
            set => this.type = value;
        }

        public ElementScope Scope => this.scope;

        public Options Option
        {
            get => this.option;
            set => this.option = value;
        }
    }
}