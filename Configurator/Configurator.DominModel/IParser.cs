using System.Collections.Generic;

namespace Configurator.DomainModel
{
    public interface IParser
    {
        ICommand Parse(IEnumerable<string> args);
    }
}