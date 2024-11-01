using UnityEngine;

namespace Project
{
    public class CharacterGroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _anchor;

        [SerializeField, Range(0.05f, 0.75f)] private float _sphereRadius = 0.4f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] QueryTriggerInteraction _triggerInteraction = QueryTriggerInteraction.Ignore;

        public bool HasGroundUnder() => Physics.CheckSphere(_anchor.position, _sphereRadius, _layerMask, _triggerInteraction);

        private void OnDrawGizmosSelected()
        {
            Color color = HasGroundUnder() ? Color.green : Color.white;
            Gizmos.color = color;

            Gizmos.DrawWireSphere(_anchor.position, _sphereRadius);
        }
    }
}
