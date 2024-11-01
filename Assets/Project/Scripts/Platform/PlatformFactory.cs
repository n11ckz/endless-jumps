using UnityEngine;
using Zenject;

namespace Project
{
    public class PlatformFactory : IPooledObjectFactory<Platform>
    {
        private const string Path = "Prefabs/Platforms/Platfrom";
        
        private readonly Platform _platformPrefab;
        private readonly IInstantiator _instantiator;

        public PlatformFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _platformPrefab = Resources.Load<Platform>(Path);
        }

        public Platform Create() => _instantiator.InstantiatePrefabForComponent<Platform>(_platformPrefab);
    }
}
