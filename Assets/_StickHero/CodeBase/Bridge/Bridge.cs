using UnityEngine;

namespace CodeBase.Bridge
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] private Transform _scaledTransform;
        private SpriteRenderer _spriteRenderer;
        
        private const float DEFAULT_HEIGHT = -2.485f; //TODO рефакторинг констант
        private const float DEVIATION_CORRECTION = 0.2f;
        
        public Transform ScaledTransform => _scaledTransform;
        
        public Vector2 EndPoint
        {
            get
            {
                return new Vector2(_spriteRenderer.bounds.max.x - DEVIATION_CORRECTION, DEFAULT_HEIGHT);
            }
        }

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
}

