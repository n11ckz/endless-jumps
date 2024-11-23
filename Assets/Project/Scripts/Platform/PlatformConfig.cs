using PrimeTween;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "Configs/Platform Config", fileName = "PlatformConfig")]
    public class PlatformConfig : ScriptableObject
    {
        [field: Header("Base Stats")]
        [field: SerializeField] public AnimationCurve LifetimeCurve { get; private set; }

        [field: Header("Animations Stats")]
        [field: SerializeField, Range(0.0f, 1.2f)] public float DropDuration { get; private set; }
        [field: SerializeField] public Vector3 RelativeDropPosition { get; private set; }
        [field: SerializeField] public Ease DropEase { get; private set; }
    }
}
