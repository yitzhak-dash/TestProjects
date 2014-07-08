using System;

namespace Configurator
{
    public class HelpCommand : ICommand
    {

        public void Execute()
        {
            Console.WriteLine("help:");
        }

        public void SetContext(CommandContext commandContext)
        {

        }

        public string Name
        {
            get { return "help"; }
        }
    }
}