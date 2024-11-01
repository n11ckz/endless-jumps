using Cinemachine;
using UnityEngine;

namespace Project
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        public void SetFollowedTarget(Transform followedTarget) => _virtualCamera.Follow = followedTarget;
    }
}
