using System.Collections.Generic;
using FinanceAssessment.Configuration;
using Xunit;

namespace FinanceAssessment.Tests.Configuration
{
    public class AppSettingsManagerTests
    {
        private readonly AppSettingsManager _appSettingsManager;
        private readonly Dictionary<string, string> _appSettings = new Dictionary<string, string>
        {
            {"productFile", "products.json"}
        };
        
        public AppSettingsManagerTests()
        {
            _appSettingsManager = new AppSettingsManager();
        }

        [Fact]
        public void AppSettingsManager_ReturnsValue_ForGivenKey()
        {
            foreach (var setting in _appSettings)
            {
                Assert.Equal(setting.Value, AppSettingsManager.Settings[setting.Key]);
            }
        }
    }
}