using TMPro;
using UnityEngine;
using Zenject;

namespace Project
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        
        private IScore _score;

        [Inject]
        private void Construct(IScore score) => _score = score;

        private void OnEnable() => _score.Changed += UpdateCurrentScoreText;

        private void OnDisable() => _score.Changed -= UpdateCurrentScoreText;

        public void UpdateHighScoreText() => _highScoreText.text = $"High Score: {_score.HighScore}";

        private void UpdateCurrentScoreText(int currentScore) => _currentScoreText.text = currentScore.ToString();
    }
}
