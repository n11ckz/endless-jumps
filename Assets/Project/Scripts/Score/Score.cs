using System;

namespace Project
{
    public class Score : IScore
    {
        public event Action<int> Changed;

        public int CurrentScore { get; private set; }
        public int HighScore { get; private set; }

        public void Increase()
        {
            CurrentScore++;
            Changed?.Invoke(CurrentScore);
        }

        public void Restore()
        {
            if (CurrentScore > HighScore)
                HighScore = CurrentScore;

            CurrentScore = 0;
            Changed?.Invoke(CurrentScore);
        }
    }
}
