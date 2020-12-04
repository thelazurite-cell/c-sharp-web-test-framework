using Coypu;
using TestAutomation.Framework.WebDriver;

namespace TestAutomationDemo.Page_Object_Models
{
    public class DotNetFiddleObjectModel: PageObjectModel
    {
        protected override string ModelLocation => "https://dotnetfiddle.net/";

        public DotNetFiddleObjectModel(Scope scope) : base(scope)
        {
        }

        public ReadonlyDomObject Overlay => new ReadonlyDomObject(new Locator(".overlay .show", LocatorType.Css), this.Scope);
        
        // Nav Bar
        public Button New => new Button(new Locator("new-button"), this.Scope);
        public Button Save => new Button(new Locator("save-button"), this.Scope);
        public Button Run => new Button(new Locator("run-button"), this.Scope);
        public Button Share => new Button(new Locator("share"), this.Scope);
        public Button Collaborate => new Button(new Locator("togetherjs"), this.Scope);

        public DomObject NugetPackages => new DomObject(new Locator(".new-package", LocatorType.Css), this.Scope);

        public ReadonlyDomObject Output => new ReadonlyDomObject(new Locator("output"), this.Scope);
    }
}