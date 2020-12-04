using Coypu;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestAutomation.Framework.ClassExtenders;
using TestAutomation.Framework.Configuration;
using TestAutomation.Framework.WebDriver;
using TestAutomationDemo.Page_Object_Models;

namespace TestAutomationDemo.Step_Definitions
{
    [Binding]
    public class DotNetFiddleDefinitions
    {
        private ScenarioContext _scenarioContext;
        private DotNetFiddleObjectModel dotNetPage;
        
        public DotNetFiddleDefinitions(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this.dotNetPage = new DotNetFiddleObjectModel(BrowserScenario.BrowserSession);
        }

        [Given("I have visited the DotNetFiddle page")]
        public void VisitTheWebsite()
        {
            this.dotNetPage.Visit();
        }

        [Given("The overlay is not visible")]
        public void OverlayIsNotVisible()
        {
            DomObject.WaitUntilObjectNotVisible(new Locator(".overlay .show", LocatorType.Css));
            BrowserScenario.BrowserSession.WaitForAjax();
        }

        [When("I click the run button")]
        public void ClickTheRunButton()
        {
            this.dotNetPage.Run.Click();
        }

        [When(@"I search for the '(.*)' package")]
        public void SearchForPackageNamed(string packageName)
        {
            this.dotNetPage.NugetPackages.Value = $"{packageName}\n";
            BrowserScenario.BrowserSession.WaitForAjax();
        }

        [When(@"I click the result that exactly matches '(.*)'")]
        public void ClickResultExactlyMatching(string packageName)
        {
            var package = ElementLocator.Locate(new Locator(packageName, LocatorType.Link));
            package.Exists().Should().BeTrue();
            package.Click();
        }

        [Then(@"Version '(.*)' should be added")]
        public void VersionShouldBeAdded(string versionNumber)
        {
            DomObject.TextNotToBePresentInElement(ElementLocator.Locate(new Locator("#menu > li > ul > li > div", LocatorType.Css)), "Versions loading...");
            var packageVersion = ElementLocator.Locate(new Locator(versionNumber, LocatorType.Link));
            packageVersion.Exists().Should().BeTrue();
            var packageSelected = ElementLocator.Locate(
                new Locator(".glyphicon.glyphicon-ok-sign", LocatorType.Css, Options.NoWait, packageVersion));
            packageSelected.Exists().Should().BeTrue();
        }
        
        [Then(@"The output window should contain '(.*)'")]
        public void OutputShouldContain(string output)
        {
            this.dotNetPage.Output.Value.Should().Contain(output);
        }
    }
}