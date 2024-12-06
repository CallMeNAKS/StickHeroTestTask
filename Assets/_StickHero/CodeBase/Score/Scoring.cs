using System;

namespace CodeBase.Score
{
    public class Scoring
    {
        private int _score = 0;
        
        public event Action<int> ScoreChanged;

        public void AddScore(int score)
        {
            if (score > 0)
            {
                _score += score;
                ScoreChanged?.Invoke(_score);
            }
        }

        public void ResetScore()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);
        }
    }
}