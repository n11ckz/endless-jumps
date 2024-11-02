namespace Project
{
    public interface IPooledObjectFactory<out T> where T : PooledObject
    {
        public T Create();
    }
}
