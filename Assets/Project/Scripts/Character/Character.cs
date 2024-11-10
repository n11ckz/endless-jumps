using System;
using UnityEngine;

namespace Project
{
    [SelectionBase]
    public class Character : MonoBehaviour
    {
        public event Action Deactivated;

        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private CharacterMovement _movement;
        
        private Vector3 _startPosition = Vector3.zero;

        private void Awake() => _startPosition = transform.position;

        public void Activate()
        {
            _movement.Activate();
            _animator.Activate();
        }

        public void Deactivate()
        {
            _animator.Deactivate();
            gameObject.Deactivate();
            Deactivated?.Invoke();
        }

        public void Restore()
        {
            transform.position = _startPosition;
            gameObject.Activate();
        }
    }
}
