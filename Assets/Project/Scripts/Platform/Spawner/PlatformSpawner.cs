using UnityEngine;
using Zenject;

namespace Project
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private PlatformSpawnPoint _spawnPoint;
        [SerializeField] private Platform _startPlatform;

        [SerializeField] private int _stock;
        
        private ObjectPool<Platform> _objectPool;
        private ICharacterMovement _characterMovement;

        [Inject]
        private void Construct(ObjectPool<Platform> pool, ICharacterMovement movement)
        {
            _objectPool = pool;
            _characterMovement = movement;
        }

        private void OnEnable() => _characterMovement.Jumped += SpawnWithDropAnimation;

        private void OnDisable() => _characterMovement.Jumped -= SpawnWithDropAnimation;

        public void SpawnInitialPlatforms()
        {
            for (int i = 0; i < _stock; i++)
                Spawn(true);
        }

        public void Restore()
        {
            _startPlatform.transform.position = _spawnPoint.StartSpawnPosition;
            _startPlatform.gameObject.Activate();
            _spawnPoint.BackToStartPosition();
            DespawnAll();
        }

        private void SpawnWithDropAnimation() => Spawn(false);

        private void Spawn(bool isInstantlySpawn)
        {
            _spawnPoint.Move();
            _objectPool.TryGet(out Platform platform);

            if (isInstantlySpawn)
            {
                platform.transform.position = _spawnPoint.CurrentSpawnPosition;
            }
            else
            {
                platform.transform.position = _spawnPoint.OffsetSpawnPosition;
                platform.DropFromAbove(_spawnPoint.CurrentSpawnPosition);
            }
        }

        private void DespawnAll()
        {
            foreach (Platform platform in _objectPool.ActiveObjects)
                platform.Release();
        }
    }
}
