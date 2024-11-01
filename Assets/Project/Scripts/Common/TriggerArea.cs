using UnityEngine;

namespace Project
{
    public abstract class TriggerArea<T> : MonoBehaviour where T : Component
    {
        private void Awake() => Initialize();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out T component))
                return;

            Process(component);
        }

        private void Initialize() => GetComponent<Collider>().isTrigger = true;

        protected abstract void Process(T component);
    }
}
