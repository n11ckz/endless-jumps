using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    public class ObjectPool<T> where T : MonoBehaviour, IPooledObject<T>
    {
        private const int DefaultCapacity = 3;

        private readonly Transform _parent = new GameObject($"{typeof(T).Name}Pool").transform;

        private readonly IPooledObjectFactory<T> _factory;
        private readonly List<T> _objects;

        public IEnumerable<T> ActiveObjects => _objects.Where((pooledObject) => pooledObject.gameObject.activeInHierarchy);

        public ObjectPool(IPooledObjectFactory<T> factory, int capacity, int stock)
        {
            _factory = factory;
            _objects = new List<T>(capacity > 0 ? capacity : DefaultCapacity);

            for (int i = 0; i < stock; i++)
            {
                T createdObject = Create();
                Release(createdObject);
            }
        }

        public T Get()
        {
            T freeObject = _objects.FirstOrDefault((pooledObject) => !pooledObject.gameObject.activeInHierarchy);

            if (freeObject == null)
                return Create();

            freeObject.gameObject.Activate();

            return freeObject;
        }

        public void Release(T pooledObject) => pooledObject.gameObject.Deactivate();

        private T Create()
        {
            T createdObject = _factory.Create();

            createdObject.transform.SetParent(_parent);
            _objects.Add(createdObject);

            return createdObject;
        }
    }
}
