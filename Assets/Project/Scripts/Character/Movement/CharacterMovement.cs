using PrimeTween;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Project
{
    public class CharacterMovement : MonoBehaviour, ICharacterMovement
    {
        public event Action Jumped;

        [SerializeField] private CharacterGroundChecker _groundChecker;

        public Vector3 Position => transform.position;

        private CharacterConfig _config;
        private IInput _input;
        private IPositionCalculator _positionCalculator;

        private bool _canJump = false;

        [Inject]
        private void Construct(CharacterConfig config, IInput input, IPositionCalculator positionCalculator)
        {
            _config = config;
            _input = input;
            _positionCalculator = positionCalculator;
        }

        private void OnEnable() => _input.DirectionReceived += Jump;

        private void OnDisable() => _input.DirectionReceived -= Jump;

        public void RestoreJump() => _canJump = true;

        private void Jump(Direction direction)
        {
            if (!_canJump)
                return;

            Vector3 vectorDirection = direction.ConvertToVector();
            Vector3 endPosition = _positionCalculator.GetNextPosition(transform.position, vectorDirection);
            StartCoroutine(Jump(transform.position, endPosition));

            Quaternion rotation = Quaternion.LookRotation(vectorDirection);
            Rotate(rotation);
        }

        private IEnumerator Jump(Vector3 startPosition, Vector3 endPosition)
        {
            _canJump = false;

            float elapsedTime = 0.0f;

            while (elapsedTime <= _config.JumpDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = Mathf.Clamp01(elapsedTime / _config.JumpDuration);
                transform.position = Vector3.Lerp(startPosition, endPosition, t).Add(y: _config.JumpCurve.Evaluate(t));

                yield return null;
            }

            _canJump = _groundChecker.HasGroundUnder();

            Jumped?.Invoke();
        }

        private void Rotate(Quaternion rotation)
        {
            if (transform.rotation == rotation)
                return;
            
            Tween.Rotation(transform, rotation, _config.RotationDuration);
        }
    }
}
