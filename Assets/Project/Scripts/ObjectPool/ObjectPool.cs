using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    public class ObjectPool<T> where T : PooledObject
    {
        private readonly List<T> _objects = new List<T>(24);
        private readonly Transform _parent = new GameObject($"{typeof(T).Name}Pool").transform;

        private readonly IPooledObjectFactory<T> _factory;

        public IEnumerable<T> ActiveObjects => _objects.Where((pooledObject) => pooledObject.gameObject.activeInHierarchy);

        private bool _isExpandable;

        public ObjectPool(IPooledObjectFactory<T> factory, int stock, bool isExpandable = true)
        {
            _factory = factory;
            _isExpandable = isExpandable;

            Fill(stock);
        }

        public bool TryGet(out T freeObject)
        {
            freeObject = _objects.FirstOrDefault((pooledObject) => !pooledObject.gameObject.activeInHierarchy);

            if (freeObject == null)
            {
                if (_isExpandable)
                {
                    freeObject = Create(true);
                    return true;
                }

                return false;
            }

            freeObject.gameObject.Activate();

            return true;
        }

        private void Fill(int stock)
        {
            for (int i = 0; i < stock; i++)
                Create();
        }

        private T Create(bool isActiveByDefault = false)
        {
            T createdObject = _factory.Create();

            if (!isActiveByDefault)
                createdObject.gameObject.Deactivate();

            createdObject.transform.SetParent(_parent);
            _objects.Add(createdObject);

            return createdObject;
        }
    }
}
