using System;

namespace Project
{
    public class Score : IScore, ISavable
    {
        public event Action<int> Changed;

        public int CurrentScore { get; private set; }
        public int HighScore { get; private set; }

        public void Save(Data data) => data.HighScore = HighScore;

        public void Load(Data data) => HighScore = data.HighScore;

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
