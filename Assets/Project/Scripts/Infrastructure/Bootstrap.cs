using UnityEngine;
using Zenject;

namespace Project
{
    public class Bootstrap : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private StateFactory _stateFactory;

        [Inject]
        private void Construct(StateMachine stateMachine, StateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
        }

        private void Start() => Initialize();

        private void Initialize()
        {
            RegisterStates();
            _stateMachine.Enter<SetupState>();
        }

        private void RegisterStates()
        {
            _stateMachine.AddState(_stateFactory.Create<SetupState>());
            _stateMachine.AddState(_stateFactory.Create<GameplayState>());
            _stateMachine.AddState(_stateFactory.Create<LoseState>());
            _stateMachine.AddState(_stateFactory.Create<RestoreState>());
        }
    }
}
