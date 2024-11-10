namespace Project
{
    public class GameplayState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Character _character;

        public GameplayState(StateMachine stateMachine, Character character)
        {
            _stateMachine = stateMachine;
            _character = character;
        }

        public void Enter()
        {
            _character.Deactivated += EnterToLoseState;
            _character.Activate();
        }

        public void Exit() => _character.Deactivated -= EnterToLoseState;

        private void EnterToLoseState() => _stateMachine.Enter<LoseState>();
    }
}
