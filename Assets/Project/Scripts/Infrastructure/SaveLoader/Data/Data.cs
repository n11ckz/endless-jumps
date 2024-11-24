using System;

namespace Project
{
    [Serializable]
    public class Data
    {
        public static readonly Data Default = new Data() { HighScore = 0 };
        
        public int HighScore { get; set; }
    }
}
