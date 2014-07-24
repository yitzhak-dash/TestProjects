using System;
using System.Text.RegularExpressions;
using System.Xml;
using Configurator.DomainModel;

namespace Configurator
{
    public class XmlConfigProvider : IXmlConfigProvider
    {
        private readonly string _filePath;

        public XmlConfigProvider(string filePath)
        {
            _filePath = filePath;
        }

        public XmlDocument LoadConfiguration()
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

        public void ChangeConfiguration(string nodePath, string attribute, string newValue, string oldValue)
        {
            var doc = LoadConfiguration();

            var xmlNodeList = SelectXmlNodes(nodePath, doc);

            if (xmlNodeList == null)
                throw new ArgumentException("nodePath not found", nodePath);

            foreach (XmlNode node in xmlNodeList)
            {
                try
                {
                    SwapOldNewValues(attribute, newValue, oldValue, node);

                    doc.Save(_filePath);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private static XmlNodeList SelectXmlNodes(string nodePath, XmlNode xmlNode)
        {
            if (xmlNode == null) throw new ArgumentNullException("xmlNode");
            return xmlNode.SelectNodes(nodePath);
        }

        private static void SwapOldNewValues(string attribute, string newValue, string oldValue, XmlNode node)
        {
            if (node.Attributes != null)
                node.Attributes[attribute].Value = node.Attributes[attribute].Value.Replace(oldValue, newValue);
        }

        public void ChangeConfiguration(string nodePath, string attribute, string newValue, Regex regex)
        {
            var doc = LoadConfiguration();

            var xmlNodeList = SelectXmlNodes(nodePath, doc);

            if (xmlNodeList == null)
                throw new ArgumentException("nodePath not found", nodePath);

            foreach (XmlNode node in xmlNodeList)
            {
                try
                {
                    var match = regex.Match(node.OuterXml);
                    if (match.Success)
                    {
                        string oldValue = match.Groups[match.Groups.Count - 1].Value;

                        SwapOldNewValues(attribute, newValue, oldValue, node);

                        doc.Save(_filePath);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
