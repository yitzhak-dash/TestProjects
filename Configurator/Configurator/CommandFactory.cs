using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(string str)
        {
            if (str == "endpoint")
                return new ChangeEndpointHostCommand();

            return new HelpCommand();
        }
    }
}
