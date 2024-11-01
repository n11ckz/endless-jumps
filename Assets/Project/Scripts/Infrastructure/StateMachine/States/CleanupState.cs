using System.Collections;
using UnityEngine;

namespace Project
{
    public class CleanupState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Character _character;
        private readonly PlatformSpawner _platformSpawner;
        private readonly Curtain _curtain;
        private readonly ICoroutineRunner _coroutineRunner;

        public CleanupState(StateMachine stateMachine, Character character, PlatformSpawner platformSpawner, Curtain curtain, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _character = character;
            _platformSpawner = platformSpawner;
            _curtain = curtain;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            Debug.Log($"Enter into {nameof(CleanupState)}");
            _coroutineRunner.StartCoroutine(Cleanup());
        }

        public void Exit() => Debug.Log($"Exit from {nameof(CleanupState)}");

        private IEnumerator Cleanup()
        {
            yield return _curtain.Show();

            _platformSpawner.Restore();
            _character.Restore();

            _stateMachine.Enter<InitializeState>();
        }
    }
}
