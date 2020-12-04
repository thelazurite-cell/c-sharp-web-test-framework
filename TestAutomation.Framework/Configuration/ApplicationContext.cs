using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TestAutomation.Framework.Configuration.Interfaces;

namespace TestAutomation.Framework.Configuration
{
    /// <summary>
    /// Portal Config - The parent class containing Config Items.
    /// These determine the specification of the portal the tests are run against.
    /// </summary>
    public class ApplicationContext
    {
        [DataMember(Name="applicationContext")]
        private IEnumerable<TestConfigurationItem> TestConfigurationItems { get; set; }

        /// <summary>
        /// Gets an item from the PortalConfigurationItems collection.
        /// </summary>
        /// <param name="tag">the tag to search for.</param>
        public string this[string tag]
        {
            get
            {
                return this.TestConfigurationItems.SingleOrDefault(i =>
                    string.Equals(i.Tag, tag, StringComparison.CurrentCultureIgnoreCase))?.Value;
            }
        }
    }
}