using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Configurator.DomainModel;

namespace Configurator
{
    public class ChangeEndpointHostCommand : ICommand
    {
        private readonly string _commandArg;
        private readonly IXmlConfigProvider _provider;
        private const string NodePath = "//system.serviceModel//client//endpoint";
        private const string NodeAttribute = "address";
        private Regex _regexForEndpoint = new Regex(@"([a-z\-\.]+)://([a-z0-9\-\.]+)");

        public ChangeEndpointHostCommand(string commandArg, IXmlConfigProvider provider)
        {
            _commandArg = commandArg;
            _provider = provider;
        }

        public void Execute()
        {
            _provider.ChangeConfiguration(NodePath, NodeAttribute, _commandArg, _regexForEndpoint);
        }

        public string Name
        {
            get { return "endpoint"; }
        }
    }
}
