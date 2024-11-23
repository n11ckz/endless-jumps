namespace Project
{
    public class SetupState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly PlatformSpawner _platformSpawner;
        private readonly Curtain _curtain;
        private readonly ScoreView _scoreView;

        public SetupState(StateMachine stateMachine, PlatformSpawner platformSpawner, Curtain curtain, ScoreView scoreView)
        {
            _stateMachine = stateMachine;
            _platformSpawner = platformSpawner;
            _curtain = curtain;
            _scoreView = scoreView;
        }

        public void Enter()
        {
            Setup();
            _stateMachine.Enter<GameplayState>();
        }

        public void Exit() => HideCurtain();

        private void Setup()
        {
            _scoreView.UpdateHighScoreText();
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
