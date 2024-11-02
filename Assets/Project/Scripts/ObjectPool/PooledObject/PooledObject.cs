using UnityEngine;

namespace Project
{
    public class PooledObject : MonoBehaviour
    {
        public void Release() => gameObject.Deactivate();
    }
}
