using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Configurator.DomainModel;
using Microsoft.Practices.Unity;

namespace Configurator
{
    class Program
    {
        private static UnityContainer _container;
        private const string ConfigFilePath = "configFilePath";

        static void InitContainer()
        {
            _container = new UnityContainer();

            string configFilePath = ConfigurationManager.AppSettings[ConfigFilePath];

            _container.RegisterType<IXmlConfigProvider, XmlConfigProvider>(new InjectionConstructor(configFilePath));
            _container.RegisterType<ICommandFactory, CommandFactory>();
            _container.RegisterType<IParser, Parser>();
        }

        static void Main(string[] args)
        {
            InitContainer();

            string[] userInput = null;

            if (args.Any())
                _container.Resolve<IParser>().Parse(args).Execute();

            Console.WriteLine("Press X to exit");

            while (true)
            {
                Console.Write("finger>>>");
                string readLine = Console.ReadLine();

                if (readLine == "x" || readLine == "X")
                    break;

                if (readLine != null) userInput = readLine.Split(' ');

                _container.Resolve<IParser>().Parse(userInput).Execute();
            }
        }
    }

}
