using UnityEngine;

namespace CodeBase.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _platformTransform;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public Transform PlatformTransform => _platformTransform;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}