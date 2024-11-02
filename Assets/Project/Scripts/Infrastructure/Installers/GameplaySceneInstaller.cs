using UnityEngine;
using Zenject;

namespace Project
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private Character _character;
        [SerializeField] private PlatformSpawner _platformSpawner;
        [SerializeField] private CameraHandler _cameraHandler;

        public override void InstallBindings()
        {
            BindSpawner();
            BindInfrastructure();
            BindCharacter();
            BindObjectPool();
            BindCameraHandler();
            BindCaclucaltor();
        }

        private void BindInfrastructure()
        {
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }

        private void BindCharacter()
        {
            Container.BindInstance(_character).AsSingle();
            Container.Bind<ICharacterMovement>().To<CharacterMovement>().FromComponentOn(_character.gameObject).AsSingle();
        }

        private void BindObjectPool()
        {
            Container.Bind<IPooledObjectFactory<Platform>>().To<PlatformFactory>().AsSingle();
            Container.Bind<ObjectPool<Platform>>().AsSingle().WithArguments(16);
        }

        private void BindSpawner() => Container.BindInstance(_platformSpawner).AsSingle();

        private void BindCameraHandler() => Container.BindInstance(_cameraHandler).AsSingle();

        private void BindCaclucaltor() => Container.Bind<IPositionCalculator>().To<GridPositionCalculator>().AsSingle().WithArguments(_grid);
    }
}
