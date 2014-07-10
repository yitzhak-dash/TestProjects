using System;
using System.Xml;

namespace Configurator
{
    public interface IXmlConfigProvider
    {
        void ChangeConfigXml(string nodePath, string attribute, string newValue, string oldValue);
    }

    public class XmlConfigProvider : IXmlConfigProvider
    {
        private readonly string _filePath;

        public XmlConfigProvider(string filePath)
        {
            _filePath = filePath;
        }

        public XmlDocument LoadConfigDocument()
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_filePath);
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        public void ChangeConfigXml(string nodePath, string attribute, string newValue, string oldValue)
        {
            var doc = LoadConfigDocument();

            var xmlNodeList = doc.SelectNodes(nodePath);

            if (xmlNodeList == null)
                throw new ArgumentException("nodePath not found", nodePath);

            foreach (XmlNode node in xmlNodeList)
            {
                try
                {
                    node.Attributes[attribute].Value = node.Attributes[attribute].Value.Replace(oldValue, newValue);

                    doc.Save(_filePath);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
