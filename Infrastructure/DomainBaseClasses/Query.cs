namespace mikkark.SCA.Infra.DomainBaseClasses
{
    public abstract class Query<TResult>
    {
        public abstract TResult Execute();
    }
}