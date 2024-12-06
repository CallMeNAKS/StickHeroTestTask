using UnityEngine;

namespace CodeBase.Character
{
    [CreateAssetMenu(menuName = "Config/Character", fileName = "CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _characterSpeed = 2f;
        [SerializeField] private float _fallAnimationDuration = 1f;
        
        public float CharacterSpeed => _characterSpeed;
        public float FallAnimationDuration => _fallAnimationDuration;
    }
}