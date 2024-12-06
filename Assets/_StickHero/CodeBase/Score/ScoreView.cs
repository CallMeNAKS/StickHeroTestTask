using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        
        private Scoring _scoring;

        [Inject]
        public void Construct(Scoring scoring)
        {
            _scoring = scoring;
        }

        private void UpdateScoreView(int newScore)
        {
            _scoreText.text = newScore.ToString();
        }

        private void OnEnable()
        {
            _scoring.ScoreChanged += UpdateScoreView;
        }

        private void OnDisable()
        {
            _scoring.ScoreChanged -= UpdateScoreView;
        }
    }
}