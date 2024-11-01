using System;
using UnityEngine;
using Zenject;

namespace Project
{
    public class KeyboardInput : IInput, ITickable
    {
        public event Action<Direction> DirectionReceived;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                DirectionReceived?.Invoke(Direction.Left);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                DirectionReceived?.Invoke(Direction.Right);
        }
    }
}
