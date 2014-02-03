namespace Infrastructure.DomainBaseClasses
{
    public abstract class Query<TResult>
    {
        public abstract TResult Execute();
    }
}