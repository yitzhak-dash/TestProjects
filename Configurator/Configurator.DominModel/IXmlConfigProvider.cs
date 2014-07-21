using System.Text.RegularExpressions;

namespace Configurator.DomainModel
{
    public interface IXmlConfigProvider
    {
        void ChangeConfiguration(string nodePath, string attribute, string newValue, string oldValue);

        void ChangeConfiguration(string nodePath, string attribute, string newValue, Regex regex);
    }
}