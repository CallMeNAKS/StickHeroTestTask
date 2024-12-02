using UnityEngine;

namespace CodeBase.Platform
{
    [CreateAssetMenu(menuName = "Config/Platform", fileName = "PlatformConfig", order = 0)]
    public class PlatformConfig : ScriptableObject
    {
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minRange;
        [SerializeField] private float _maxRange;
        
        
        public float MinSize => _minSize;
        public float MaxSize => _maxSize;
        public float MinRange => _minRange;
        public float MaxRange => _maxRange;
    }
}