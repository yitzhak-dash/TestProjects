namespace Configurator.DomainModel
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}
