using UnityEngine;

namespace CodeBase.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform _bridgePoint;
        
        public Transform BridgePoint => _bridgePoint;
    }
}