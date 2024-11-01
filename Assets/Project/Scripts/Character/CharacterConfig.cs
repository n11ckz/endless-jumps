using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "Configs/Character Config", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [field: Header("Movement Stats")]
        [field: SerializeField, Range(0.0f, 0.25f)] public float JumpDuration { get; private set; }
        [field: SerializeField] public AnimationCurve JumpCurve { get; private set; }
        [field: SerializeField, Range(0.0f, 0.15f)] public float RotationDuration { get; private set; }

        [field: Header("Animation Stats")]
        [field: SerializeField, Min(0)] public int AnimationCount { get; private set; }
        [field: SerializeField] public Vector2 AnimationDelayRange { get; private set; }
    }
}
