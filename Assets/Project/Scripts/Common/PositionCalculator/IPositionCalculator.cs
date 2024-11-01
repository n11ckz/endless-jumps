using UnityEngine;

namespace Project
{
    public interface IPositionCalculator
    {
        public Vector3 GetNextPosition(Vector3 currentPosition, Vector3 direction);
    }
}
