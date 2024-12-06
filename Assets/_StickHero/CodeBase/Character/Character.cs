using UnityEngine;
using Animator = CodeBase.Character.CharacterAnimation.Animator;

namespace CodeBase.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform _bridgePoint;
        [SerializeField] private Animator _animator;
        public Transform BridgePoint => _bridgePoint;
        public Animator Animator => _animator;
    }
}