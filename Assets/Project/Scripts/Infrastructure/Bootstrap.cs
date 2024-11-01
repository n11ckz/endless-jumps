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
            _stateMachine.AddState(_stateFactory.Create<InitializeState>());
            _stateMachine.AddState(_stateFactory.Create<GameplayState>());
            _stateMachine.AddState(_stateFactory.Create<CleanupState>());

            _stateMachine.Enter<InitializeState>();
        }
    }
}
