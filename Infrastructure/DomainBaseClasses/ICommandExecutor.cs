namespace Infrastructure.DomainBaseClasses
{
    public interface ICommandExecutor
    {
        void Execute(Command cmd);
    }
}