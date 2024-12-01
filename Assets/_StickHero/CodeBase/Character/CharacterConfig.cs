using UnityEngine;

namespace CodeBase.Character
{
    [CreateAssetMenu(menuName = "Config/Character", fileName = "CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _characterSpeed = 2f;
        [SerializeField] private float _fallAnimationDuration = 1f;
        [SerializeField] private Character _characterPrefab;
        
        public float CharacterSpeed => _characterSpeed;
        public float FallAnimationDuration => _fallAnimationDuration;
        public Character CharacterPrefab => _characterPrefab;
    }
}