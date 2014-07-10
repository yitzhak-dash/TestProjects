using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IXmlConfigProvider _provider;

        public CommandFactory(IXmlConfigProvider provider)
        {
            _provider = provider;
        }

        public ICommand Create(string commandStr, string commandArg)
        {
            if (commandStr == "endpoint")
                return new ChangeEndpointHostCommand(commandArg, _provider);

            return new HelpCommand();
        }
    }
}
