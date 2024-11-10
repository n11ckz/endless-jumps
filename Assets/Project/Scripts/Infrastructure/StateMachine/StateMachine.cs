using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        private IState _currentState;

        public void AddState(IState state)
        {
            Type stateType = state.GetType();
            _states.TryAdd(stateType, state);
        }

        public void Enter<T>() where T : IState
        {
            _currentState?.Exit();

            if (!_states.TryGetValue(typeof(T), out IState state))
            {
                Debug.LogError($"{typeof(T).Name} not found");
                return;
            }

            _currentState = state;
            _currentState.Enter();
        }
    }
}
