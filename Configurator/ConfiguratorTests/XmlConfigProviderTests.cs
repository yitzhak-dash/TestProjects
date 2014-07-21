using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configurator;

namespace ConfiguratorTests
{
    [TestClass]
    public class XmlConfigProviderTests
    {
        [TestMethod]
        public void FirstStep()
        {
            var xmlConfigurProvider = new XmlConfigProvider("");
            var xml = xmlConfigurProvider.LoadConfiguration();
        }
    }
}
