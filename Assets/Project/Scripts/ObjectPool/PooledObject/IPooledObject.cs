using System;

namespace Project
{
    public interface IPooledObject<T>
    {
        public event Action<T> Released;
    }
}
