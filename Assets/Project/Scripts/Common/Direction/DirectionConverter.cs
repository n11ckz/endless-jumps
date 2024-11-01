using System;
using UnityEngine;

namespace Project
{
    public static class DirectionConverter
    {
        public static Vector3 ConvertToVector(this Direction direction) => direction switch
        {
            Direction.None => Vector3.zero,
            Direction.Left => Vector3.forward,
            Direction.Right => Vector3.right,
            _ => throw new ArgumentException()
        };
    }
}
