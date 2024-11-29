using UnityEngine;

namespace CodeBase.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _platformTransform;

        public Transform PlatformTransform => _platformTransform;
    }
}