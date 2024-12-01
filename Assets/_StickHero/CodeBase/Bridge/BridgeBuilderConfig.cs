using UnityEngine;

namespace CodeBase.Bridge
{
    [CreateAssetMenu(menuName = "Config/Bridge", fileName = "BridgeConfig", order = 0)]
    public class BridgeBuilderConfig : ScriptableObject
    { 
        [SerializeField] private float _buildSpeed = 1.5f;
        [SerializeField] private float _maxHeight = 15f;
        [SerializeField] private float _fallSpeed = 1f;
        [SerializeField] private Bridge _bridgePrefab;
        
        public float BuildSpeed => _buildSpeed;
        public float MaxHeight => _maxHeight;
        public float FallSpeed => _fallSpeed;
        public Bridge BridgePrefab => _bridgePrefab;
    }
}