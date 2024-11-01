using UnityEngine;

namespace Project
{
    public class InitializeState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Character _character;
        private readonly PlatformSpawner _platformSpawner;
        private readonly CameraHandler _cameraHandler;
        private readonly Curtain _curtain;

        public InitializeState(StateMachine levelStateMachine, Character character, PlatformSpawner platformSpawner, CameraHandler cameraHandler, Curtain curtain)
        {
            _stateMachine = levelStateMachine;
            _character = character;
            _platformSpawner = platformSpawner;
            _cameraHandler = cameraHandler;
            _curtain = curtain;
        }

        public void Enter()
        {
            Debug.Log($"Enter into {nameof(InitializeState)}");
            
            Inititalize();

            _stateMachine.Enter<GameplayState>();
        }

        public void Exit()
        {
            Debug.Log($"Exit from {nameof(InitializeState)}");

            if (_curtain.IsHidden)
                return;

            _curtain.HideWithDelay();
        }

        private void Inititalize()
        {
            _character.Initialize();
            _platformSpawner.Initialize();
            _cameraHandler.SetFollowedTarget(_character.transform);
        }
    }
}
