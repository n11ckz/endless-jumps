using UnityEngine;
using Zenject;

namespace Project
{
    public class CharacterAnimator : MonoBehaviour
    {
        private readonly int _hashedLookTrigger = Animator.StringToHash("Look");
        private readonly int _hashedLookAnimationIndex = Animator.StringToHash("LookAnimationIndex");

        [SerializeField] private Animator _animator;

        private CharacterConfig _config;
        private Timer _timer;

        [Inject]
        private void Construct(CharacterConfig config, Timer timer)
        {
            _config = config;
            _timer = timer;
        }

        private void OnEnable() => _timer.Finished += PlayRandomIdleAnimation;

        private void OnDisable() => _timer.Finished -= PlayRandomIdleAnimation;

        public void Activate()
        {
            float delayBetweenAnimations = Random.Range(_config.AnimationDelayRange.x, _config.AnimationDelayRange.y);
            _timer.Start(delayBetweenAnimations);
        }

        public void Deactivate() => _timer.Stop();

        private void PlayRandomIdleAnimation()
        {
            int animationIndex = Random.Range(0, _config.AnimationCount);
            
            _animator.SetInteger(_hashedLookAnimationIndex, animationIndex);
            _animator.SetTrigger(_hashedLookTrigger);

            Activate();
        }
    }
}
