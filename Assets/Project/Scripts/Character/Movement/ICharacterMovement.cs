using System;
using UnityEngine;

namespace Project
{
    public interface ICharacterMovement
    {
        public event Action Jumped;

        public Vector3 Position { get; }
    }
}
