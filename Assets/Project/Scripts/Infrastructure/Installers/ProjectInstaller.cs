using System;
using UnityEngine;
using Zenject;

namespace Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private Curtain _curtain;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private PlatformConfig _platformConfig;

        public override void InstallBindings()
        {
            BindInfrastructure();
            BindInput();
            BindConfigs();
            BindUI();
            BindCoroutineRunner();
            BindTimer();
        }

        private void BindInfrastructure() => Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindInput()
        {
            Type inputType = Application.isMobilePlatform ? typeof(TouchscreenInput) : typeof(KeyboardInput);
            Container.BindInterfacesTo(inputType).AsSingle();

            Debug.Log($"Input from {inputType.Name}");
        }

        private void BindConfigs()
        {
            Container.BindInstance(_characterConfig).AsSingle();
            Container.BindInstance(_platformConfig).AsSingle();
        }

        private void BindUI() => Container.BindInstance(_curtain).AsSingle();

        private void BindCoroutineRunner() => Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();

        private void BindTimer() => Container.Bind<Timer>().AsTransient().
            OnInstantiated<Timer>((context, timer) => context.Container.Resolve<TickableManager>().Add(timer));
    }
}
