using System;
using UnityEngine;
using Zenject;

namespace Project
{
    public class Timer : ITickable
    {
        public event Action Finished;

        private bool _isCountdown;
        private float _remainingTime;

        public void Start(float desiredTime)
        {
            _remainingTime = Mathf.Max(desiredTime, 0.0f);
            _isCountdown = true;
        }

        public void Stop() => _isCountdown = false;

        public void Tick()
        {
            if (!_isCountdown)
                return;

            Countdown();
        }

        private void Countdown()
        {
            _remainingTime -= Time.deltaTime;

            if (_remainingTime <= 0.0f)
            {
                Stop();
                Finished?.Invoke();
            }
        }
    }
}
