using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public class Parser
    {
        private readonly ICommandFactory _factory;

        public Parser(ICommandFactory factory)
        {
            _factory = factory;
        }

        public ICommand Parse(IEnumerable<string> args)
        {
            var list = args as IList<string> ?? args.ToList();

            if (args == null || !list.Any())
                return new HelpCommand();

            var command = _factory.Create(list[0]);
            command.SetContext(new CommandContext().Add("To", list[1]));

            return command;
        }
    }
}
