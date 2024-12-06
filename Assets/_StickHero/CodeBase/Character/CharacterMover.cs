using System.Collections;
using CodeBase.Character.CharacterAnimation;
using CodeBase.Infrastructure.CoroutineService;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Character
{
    public class CharacterMover
    {
        private readonly Character _character;
        private readonly Transform _characterTransform;
        private readonly Coroutines _coroutines;
        private readonly CharacterConfig _characterConfig;
        private readonly Vector3 _startPosition;

        private readonly Vector3 _fallPosition = Vector3.down * 10;

        public CharacterMover(Character character,
            Coroutines coroutines,
            CharacterConfig characterConfig,
            Transform characterStartTransform)
        {
            _character = character;
            _characterTransform = character.transform;
            _coroutines = coroutines;
            _characterConfig = characterConfig;
            _startPosition = characterStartTransform.position;
        }

        public IEnumerator Move(Vector3 endPosition)
        {
            _character.Animator.PlayAnimation(CharacterAnimationNames.Walk);
            
            while (Vector3.Distance(_characterTransform.position, endPosition) > 0.01f)
            {
                _characterTransform.position = Vector3.MoveTowards(
                    _characterTransform.position,
                    endPosition,
                    _characterConfig.CharacterSpeed * Time.deltaTime);

                yield return null;
            }

            _characterTransform.position = endPosition;
            _character.Animator.PlayAnimation(CharacterAnimationNames.Idle);
        }

        public void TeleportToStart()
        {
            _characterTransform.transform.position = _startPosition;
        }

        public IEnumerator Fall()
        {
            var endPosition = _characterTransform.position + _fallPosition;

            yield return _characterTransform
                .DOMove(endPosition, _characterConfig.FallAnimationDuration)
                .WaitForCompletion();
        }
    }
}