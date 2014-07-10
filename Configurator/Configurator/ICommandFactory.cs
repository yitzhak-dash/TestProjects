using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public interface ICommandFactory
    {
        ICommand Create(string commandStr, string commandArg);
    }
}
