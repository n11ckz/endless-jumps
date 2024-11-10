using PrimeTween;
using UnityEngine;
using Zenject;

namespace Project
{
    [RequireComponent(typeof(BoxCollider))]
    public class CharacterDeathArea : TriggerArea<Character>
    {
        [SerializeField, Min(1.0f)] private float _delayAfterEntering = 2.0f;
        [SerializeField] private Vector3 _positionOffset = Vector3.down;

        private CameraHandler _cameraHandler;
        private ICharacterMovement _characterMovement;

        [Inject]
        private void Construct(CameraHandler cameraHandler, ICharacterMovement characterMovement)
        {
            _cameraHandler = cameraHandler;
            _characterMovement = characterMovement;
        }

        private void OnEnable() => _characterMovement.Jumped += MoveUnderCharacter;

        private void OnDisable() => _characterMovement.Jumped -= MoveUnderCharacter;

        private void MoveUnderCharacter() => transform.position = _characterMovement.Position + _positionOffset;

        protected override void Process(Character character)
        {
            _cameraHandler.SetFollowedTarget(null);
            Tween.Delay(_delayAfterEntering, () => character.Deactivate());
        }
    }
}
