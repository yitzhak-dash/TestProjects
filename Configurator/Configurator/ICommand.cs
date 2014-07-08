using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();

        void SetContext(CommandContext commandContext);
    }
}
