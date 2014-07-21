using System;
using Configurator.DomainModel;

namespace Configurator
{
    public class HelpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("help:");
        }

     
        public string Name
        {
            get { return "help"; }
        }
    }
}