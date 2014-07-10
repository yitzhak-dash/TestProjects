using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public class ChangeEndpointHostCommand : ICommand
    {
        private readonly string _commandArg;
        private readonly IXmlConfigProvider _provider;
        private const string NodePath = "//system.serviceModel//client//endpoint";
        private const string NodeAttribute = "address";

        public ChangeEndpointHostCommand(string commandArg,IXmlConfigProvider provider)
        {
            _commandArg = commandArg;
            _provider = provider;
        }

        public void Execute()
        {
           
        }

        public string Name
        {
            get { return "endpoint"; }
        }
    }
}
