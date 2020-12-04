using System.Collections.Generic;

namespace TestAutomation.Framework.Configuration.Interfaces
{
    /// <summary>
    /// The interface for test configuration. This describes the config allowed for SpecFlow tests.
    /// </summary>
    public interface IFrameworkConfiguration
    {
        FrameworkOptions FrameworkOptions { get; set; }
        
        /// <summary>
        /// Gets or sets a collection of tags that are used by SpecFlow tests. These determine whether a test or test suite
        /// should be run.
        /// </summary>
        IEnumerable<TestCategory> TestCategories { get; set; }

        /// <summary>
        /// Gets or sets the configuration. This determines constraints which the tests should meet.
        /// </summary>
        IEnumerable<TestConfigurationItem> ApplicationContext { get; set; }

        
        TestCategory GetCategoryConfig(string categoryName);

        string GetAppContextItem(string configItemName);
    }
}