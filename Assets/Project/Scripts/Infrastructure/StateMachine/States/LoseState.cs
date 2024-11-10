namespace Project
{
    public class LoseState : IState
    {
        private readonly StateMachine _stateMachine;

        public LoseState(StateMachine stateMachine) => _stateMachine = stateMachine;

        public void Enter()
        {
            // TODO: show UI window and enter to revive or restore state
            _stateMachine.Enter<RestoreState>();
        }

        public void Exit() { }
    }
}
