namespace Project
{
    public class DataLoadState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Saver _saver;

        public DataLoadState(StateMachine stateMachine, Saver saver)
        {
            _stateMachine = stateMachine;
            _saver = saver;
        }

        public void Enter()
        {
            _saver.Load();
            _stateMachine.Enter<SetupState>();
        }

        public void Exit() { }
    }
}
