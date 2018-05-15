namespace ASPCoreWithAngular.Mappers
{
    public abstract class DataMapper<TSource, TTarget> where TSource : class where TTarget : class
    {
        public abstract TTarget Map(TSource source);
    }
}