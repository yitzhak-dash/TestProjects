using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    public class CommandContext
    {
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public object this[string paramName]
        {
            get
            {
                if (_dictionary.ContainsKey(paramName))
                    return _dictionary[paramName];
                return null;
            }
            set
            {
                if (!_dictionary.ContainsKey(paramName))
                    _dictionary.Add(paramName, value);
                else
                    _dictionary[paramName] = value;
            }
        }

        public CommandContext Add(string paramName, object val)
        {
            this[paramName] = val;
            return this;
        }
    }
}
