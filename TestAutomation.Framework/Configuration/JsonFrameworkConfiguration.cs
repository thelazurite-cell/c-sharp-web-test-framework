using System.Collections.Generic;
using System.Linq;
using TestAutomation.Framework.Configuration.Interfaces;

namespace TestAutomation.Framework.Configuration
{
    /// <inheritdoc />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class JsonFrameworkConfiguration : IFrameworkConfiguration
    {
        /// <inheritdoc/>
        public FrameworkOptions FrameworkOptions { get; set; }

        /// <inheritdoc/>
        public IEnumerable<TestCategory> TestCategories { get; set; }

        /// <inheritdoc/>
        public IEnumerable<TestConfigurationItem> ApplicationContext { get; set; }

        public TestCategory GetCategoryConfig(string categoryName)
        {
            return this.TestCategories.FirstOrDefault(itm => itm.Category == categoryName);
        }
        public string GetAppContextItem(string configItemName)
        {
            return this.ApplicationContext.FirstOrDefault(itm => itm.Tag == configItemName)?.Value;
        }
    }
}