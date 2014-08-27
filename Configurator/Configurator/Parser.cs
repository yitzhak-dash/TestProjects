using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.DomainModel;

namespace Configurator
{
    public class Parser : IParser
    {
        private readonly ICommandFactory _factory;

        public Parser(ICommandFactory factory)
        {
            _factory = factory;
        }

        public ICommand Parse(IEnumerable<string> args)
        {
            var list = args as IList<string> ?? args.ToList();

            if (args == null || list.Count < 2)
                return new HelpCommand();

            var pars = list.ToList();

            pars.RemoveAt(0);

            var command = _factory.Create(list[0], string.Join(" ", pars));

            return command;
        }
    }
}
