using System;

namespace Project
{
    public interface IScore
    {
        public event Action<int> Changed;

        public int CurrentScore { get; }
        public int HighScore { get; }
    }
}
