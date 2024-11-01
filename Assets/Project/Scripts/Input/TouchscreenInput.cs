using System;
using UnityEngine;
using Zenject;

namespace Project
{
    public class TouchscreenInput : IInput, ITickable
    {
        private const int PrimaryTouchIndex = 0;

        public event Action<Direction> DirectionReceived;

        private readonly int _halfWidthScreen = Screen.width / 2;

        public void Tick()
        {
            if (Input.touchCount == 0)
                return;

            Touch touch = Input.GetTouch(PrimaryTouchIndex);

            if (touch.phase != TouchPhase.Began)
                return;

            Direction direction = touch.position.x <= _halfWidthScreen ? Direction.Left : Direction.Right;
            DirectionReceived?.Invoke(direction);
        }
    }
}
