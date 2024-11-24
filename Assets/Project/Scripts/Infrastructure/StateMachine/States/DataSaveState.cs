namespace Project
{
    public class DataSaveState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly DataPresenter _dataPresenter;
        private readonly Saver _saver;
        private readonly IScore _score;

        public DataSaveState(StateMachine stateMachine, DataPresenter dataPresenter, Saver saver, IScore score)
        {
            _stateMachine = stateMachine;
            _dataPresenter = dataPresenter;
            _saver = saver;
            _score = score;
        }

        public void Enter()
        {
            TrySaveData();
            _stateMachine.Enter<SetupState>();
        }

        public void Exit() { }

        private void TrySaveData()
        {
            if (_dataPresenter.Data.HighScore >= _score.HighScore)
                return;

            _saver.Save();
        }
    }
}
