namespace Project
{
    public class SetupState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly PlatformSpawner _platformSpawner;
        private readonly Curtain _curtain;

        public SetupState(StateMachine stateMachine, PlatformSpawner platformSpawner, Curtain curtain)
        {
            _stateMachine = stateMachine;
            _platformSpawner = platformSpawner;
            _curtain = curtain;
        }

        public void Enter()
        {
            Setup();
            _stateMachine.Enter<GameplayState>();
        }

        public void Exit() => HideCurtain();

        private void Setup()
        {
            // TODO: show and update UI
            _platformSpawner.SpawnInitialPlatforms();
        }

        private void HideCurtain()
        {
            if (_curtain.IsHidden)
                return;

            _curtain.HideWithDelay();
        }
    }
}
