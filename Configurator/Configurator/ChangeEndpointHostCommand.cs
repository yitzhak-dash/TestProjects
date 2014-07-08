using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public class ChangeEndpointHostCommand : ICommand
    {
        private CommandContext _commandContext;
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void SetContext(CommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public string Name
        {
            get { return "endpoint"; }
        }
    }
}
