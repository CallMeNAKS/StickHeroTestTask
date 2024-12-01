using System.Collections;
using CodeBase.Infrastructure.CoroutineService;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Character
{
    public class CharacterMover
    {
        private readonly Transform _characterTransform;
        private readonly Coroutines _coroutines;
        private readonly CharacterConfig _characterConfig;
        
        private readonly Vector3 _fallPosition = Vector3.down * 10;

        public CharacterMover(Transform characterTransform, Coroutines coroutines, CharacterConfig characterConfig)
        {
            _characterTransform = characterTransform;
            _coroutines = coroutines;
            _characterConfig = characterConfig;
        }

        public IEnumerator Move(Vector3 endPosition)
        {
            yield return _coroutines.StartCoroutine(MoveCoroutine(endPosition));
        }

        public void Fall()
        {
            var endPosition = _characterTransform.position + _fallPosition;

            _characterTransform.DOMove(endPosition, _characterConfig.FallAnimationDuration);
        }

        private IEnumerator MoveCoroutine(Vector3 endPosition)
        {
            while (Vector3.Distance(_characterTransform.position, endPosition) > 0.01f)
            {
                _characterTransform.position = Vector3.MoveTowards(
                    _characterTransform.position,
                    endPosition,
                    _characterConfig.CharacterSpeed * Time.deltaTime);

                yield return null;
            }

            _characterTransform.position = endPosition;
        }
    }
}