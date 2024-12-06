using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.UI.Animation
{
    public class TextAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 _scaleFactor = new Vector3(1.2f, 1.2f, 1.2f);
        private Tween _currentTween;

        private void OnEnable()
        {
            StartScaling();
        }

        private void OnDisable()
        {
            _currentTween?.Kill();
        }

        private void StartScaling()
        {
            var scale = transform.localScale;

            _currentTween = transform.DOScale(_scaleFactor, 1f)
                .OnComplete(() => transform.DOScale(scale, 1f))
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}