using System;
using UnityEngine;

namespace Project
{
    [SelectionBase]
    public class Character : MonoBehaviour
    {
        public event Action Destroyed;

        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private CharacterMovement _movement;
        
        private Vector3 _startPosition = Vector3.zero;

        private void Awake() => _startPosition = transform.position;

        public void Initialize()
        {
            if (!gameObject.activeInHierarchy)
                gameObject.Activate();
            
            _animator.Activate();
        }

        public void ActivateMovement() => _movement.RestoreJump();

        public void DeactivateAnimator() => _animator.Deactivate();

        public void Destroy()
        {
            gameObject.Deactivate();
            Destroyed?.Invoke();
        }

        public void Restore() => transform.position = _startPosition;
    }
}
