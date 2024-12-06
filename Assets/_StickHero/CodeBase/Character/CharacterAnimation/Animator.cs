using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Character.CharacterAnimation
{
    public enum CharacterAnimationNames
    {
        Idle,
        Walk,
        ActiveWait
    }
    
    public class Animator : MonoBehaviour
    {
        [SerializeField] private GameObject _walkAnimation;
        [SerializeField] private GameObject _activeWaitAnimation;
        [SerializeField] private GameObject _waitAnimation;

        private readonly Dictionary<CharacterAnimationNames, GameObject> _animations = new();
        private CharacterAnimationNames _currentAnimation = CharacterAnimationNames.Idle;
        
        private void Awake()
        {
            _animations.Add(CharacterAnimationNames.Walk, _walkAnimation);
            _animations.Add(CharacterAnimationNames.ActiveWait, _activeWaitAnimation);
            _animations.Add(CharacterAnimationNames.Idle, _waitAnimation);
            
            PlayAnimation(CharacterAnimationNames.Idle);
        }

        public void PlayAnimation(CharacterAnimationNames animationName)
        {
            if (animationName == _currentAnimation) return;
            
            _animations[_currentAnimation].gameObject.SetActive(false);
            _animations[animationName].gameObject.SetActive(true);
            _currentAnimation = animationName;
        }
    }
}