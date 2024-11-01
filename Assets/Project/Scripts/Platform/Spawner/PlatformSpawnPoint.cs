using UnityEngine;
using Zenject;

namespace Project
{
    public class PlatformSpawnPoint : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 1.0f)] private float _chance = 0.5f;
        [SerializeField] private Vector3 _spawnOffset = Vector3.up;

        public Vector3 StartSpawnPosition { get; private set; }
        public Vector3 CurrentSpawnPosition => transform.position;
        public Vector3 OffsetSpawnPosition => transform.position + _spawnOffset;

        private IPositionCalculator _positionCalculator;

        [Inject]
        private void Construct(IPositionCalculator positionCalculator) => _positionCalculator = positionCalculator;

        private void Awake() => Initialize();

        public void Move()
        {
            Vector3 vectorDirection = GetRandomVectorDirection();
            transform.position = _positionCalculator.GetNextPosition(transform.position, vectorDirection);
        }

        public void BackToStartPosition() => transform.position = StartSpawnPosition;

        private void Initialize() => StartSpawnPosition = transform.position;

        private Vector3 GetRandomVectorDirection()
        {
            Direction direction = Random.value >= _chance ? Direction.Left : Direction.Right;
            return direction.ConvertToVector();
        }
    }
}
