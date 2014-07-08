using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Configurator
{
    class Program
    {
        private const string ConfigFilePath = "configFilePath";
        private const string Localhost = "localhost";
        private const string Remotehost = "remotehost";
        private const string NodePath = "//system.serviceModel//client//endpoint";


        static void Main(string[] args)
        {
            if (args == null || !args.Any())
                return;
            var command = args[0];

            //var command = "local";

            if (command == "local")
                ToLocalhost();
            if (command == "remote")
                ToRemotehost();
        }

        private static void ToRemotehost()
        {
            ChangeEndpointAddress(ConfigurationManager.AppSettings[Remotehost], ConfigurationManager.AppSettings[Localhost]);
        }

        private static void ToLocalhost()
        {
            ChangeEndpointAddress(ConfigurationManager.AppSettings[Localhost], ConfigurationManager.AppSettings[Remotehost]);

        }



        public static string GetEndpointAddress()
        {
            return LoadConfigDocument().SelectSingleNode(NodePath).Attributes["address"].Value;
        }

        public static void ChangeEndpointAddress(string newEndpointAddress, string oldEndpointAddress)
        {
            // load config document for current assembly
            XmlDocument doc = LoadConfigDocument();

            foreach (XmlNode node in doc.SelectNodes(NodePath))
            {
                if (node == null)
                    throw new InvalidOperationException("Error. Could not find endpoint node in config file.");

                try
                {
                    // select the 'add' element that contains the key
                    //XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    node.Attributes["address"].Value = node.Attributes["address"].Value.Replace(oldEndpointAddress, newEndpointAddress);

                    doc.Save(GetConfigFilePath());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        private static string GetConfigFilePath()
        {
            return ConfigurationManager.AppSettings[ConfigFilePath];
            //return Assembly.GetExecutingAssembly().Location + ".config";
        }
    }

}
