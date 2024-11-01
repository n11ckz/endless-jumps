using PrimeTween;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Project
{
    public class Platform : MonoBehaviour, IPooledObject<Platform>
    {
        public event Action<Platform> Released;

        [SerializeField] private PlatformTriggerArea _triggerArea;

        private PlatformConfig _config;
        private Timer _timer;

        [Inject]
        private void Construct(PlatformConfig config, Timer timer)
        {
            _config = config;
            _timer = timer;
        }

        private void OnEnable()
        {
            _triggerArea.CharacterEntered += StartTimer;
            _timer.Finished += Release;
        }

        private void OnDisable()
        {
            _triggerArea.CharacterEntered -= StartTimer;
            _timer.Finished -= Release;
        }

        public void DropFromAbove(Vector3 endPosition) => StartCoroutine(Drop(endPosition));

        private void StartTimer() => _timer.Start(_config.Lifetime);

        private void Release()
        {
            Vector3 endPosition = transform.position + _config.RelativeDropPosition;
            StartCoroutine(Drop(endPosition, () => Released?.Invoke(this)));
        }

        private IEnumerator Drop(Vector3 endPosition, Action callback = null)
        {
            Tween tween = Tween.Position(transform, endPosition, _config.DropDuration, _config.DropEase);

            yield return tween.ToYieldInstruction();

            callback?.Invoke();
        }
    }
}
