using PrimeTween;
using UnityEngine;
using Zenject;

namespace Project
{
    public class Platform : PooledObject
    {
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
            _timer.Finished += DropDown;
        }

        private void OnDisable()
        {
            _triggerArea.CharacterEntered -= StartTimer;
            _timer.Finished -= DropDown;
        }

        public void DropFromAbove(Vector3 endPosition) => Drop(endPosition, false);

        private void StartTimer() => _timer.Start(_config.Lifetime);

        private void DropDown()
        {
            Vector3 endPosition = transform.position + _config.RelativeDropPosition;
            Drop(endPosition, true);
        }

        private void Drop(Vector3 endPosition, bool hasCharacterStepped)
        {
            Tween tween = Tween.Position(transform, endPosition, _config.DropDuration, _config.DropEase);

            if (hasCharacterStepped)
                tween.OnComplete(() => Release());
        }
    }
}
