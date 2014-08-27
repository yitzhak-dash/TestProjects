using System;
using System.IO;
using System.Linq;
using Configurator.DomainModel;

namespace Configurator
{
    public class AddTemplatePartCommand : ICommand
    {
        private readonly string _csFilePath;

        public static string GetName()
        {
            return "addTemplateParts";
        }

        public AddTemplatePartCommand(string commandArg)
        {
            _csFilePath = commandArg.Trim('"');

            if (!File.Exists(_csFilePath))
                throw new FileNotFoundException("", _csFilePath);          
        }

        public string Name { get { return GetName(); } }

        public void Execute()
        {
            string fileText = File.ReadAllText(_csFilePath);

            var parts = fileText.Split(new[] { "GetTemplateChild(\"", "\")" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s.StartsWith("PART_"))
                .Distinct()
                .Select(s => string.Format("[TemplatePart(Name = \"{0}\")]", s)).ToArray();



            var i = fileText.IndexOf("public class", StringComparison.Ordinal);

            //Save copy
            File.WriteAllText(_csFilePath + "_copy", fileText);

            fileText = fileText.Insert(i, string.Join("\n", parts));

            File.WriteAllText(_csFilePath, fileText);
        }
    }
}