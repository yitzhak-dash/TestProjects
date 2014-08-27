using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.DomainModel;

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
            if (commandStr == AddTemplatePartCommand.GetName())
                return new AddTemplatePartCommand(commandArg);

            return new HelpCommand();
        }
    }
}
