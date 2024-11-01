using System;
using System.Collections.Generic;

namespace Project
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        private IState _currentState;

        public void AddState(IState state)
        {
            Type stateType = state.GetType();

            if (_states.ContainsKey(stateType))
                return;

            _states.Add(stateType, state);
        }

        public void Enter<T>() where T : IState
        {
            if (!_states.TryGetValue(typeof(T), out IState state))
                return;

            _currentState?.Exit();

            _currentState = state;

            _currentState.Enter();
        }
    }
}
