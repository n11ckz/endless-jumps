namespace Project
{
    public interface IPooledObjectFactory<out T>
    {
        public T Create();
    }
}
