using UnityEngine;

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
            Debug.Log($"Enter into {nameof(GameplayState)}");

            _character.Destroyed += Lose;
            _character.ActivateMovement();
        }

        public void Exit()
        {
            Debug.Log($"Exit from {nameof(GameplayState)}");

            _character.Destroyed -= Lose;
        }

        private void Lose() => _stateMachine.Enter<CleanupState>();
    }
}
