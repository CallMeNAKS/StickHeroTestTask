using UnityEngine;

namespace CodeBase.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _platformTransform;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public Transform PlatformTransform => _platformTransform;
        // public Bounds PlatformBounds => _spriteRenderer.bounds; //TODO длинее обращение к конкретной точке
        public float MaxX => _spriteRenderer.bounds.max.x;
        public float MinX => _spriteRenderer.bounds.min.x;
        public float MaxY => _spriteRenderer.bounds.max.y;
    }
}