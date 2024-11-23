using System.Collections;

namespace Project
{
    public class RestoreState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Character _character;
        private readonly PlatformSpawner _platformSpawner;
        private readonly CameraHandler _cameraHandler;
        private readonly Curtain _curtain;
        private readonly Score _score;
        private readonly ICoroutineRunner _coroutineRunner;

        public RestoreState(StateMachine stateMachine, Character character, PlatformSpawner platformSpawner, CameraHandler cameraHandler,
            Curtain curtain, Score score, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _character = character;
            _platformSpawner = platformSpawner;
            _cameraHandler = cameraHandler;
            _curtain = curtain;
            _score = score;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter() => _coroutineRunner.StartCoroutine(Restore());

        public void Exit() { }

        private IEnumerator Restore()
        {
            yield return _curtain.Show();

            _platformSpawner.Restore();
            _character.Restore();
            _cameraHandler.SetFollowedTarget(_character.transform);
            _score.Restore();

            _stateMachine.Enter<SetupState>();
        }
    }
}
