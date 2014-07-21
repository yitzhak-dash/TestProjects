namespace Configurator.DomainModel
{
    public interface ICommandFactory
    {
        ICommand Create(string commandStr, string commandArg);
    }
}
