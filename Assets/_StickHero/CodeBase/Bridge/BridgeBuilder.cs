using System;
using System.Collections;
using CodeBase.Character.CharacterAnimation;
using CodeBase.Infrastructure.CoroutineService;
using CodeBase.Infrastructure.GenericSource;
using CodeBase.Input;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Bridge
{
    public class BridgeBuilder
    {
        private readonly GenericSource<Bridge> _bridgeSource;
        private readonly BridgeBuilderConfig _builderConfig;
        private readonly Transform _placeForBridge;
        private readonly Coroutines _coroutines;
        private readonly IInputHandler _input;
        private readonly Character.Character _character;

        private Bridge _currentBridge;
        private Bridge _completedBridge;
        private bool _isOutgrown;

        public event Action BuildCompleted;

        public BridgeBuilder(GenericSource<Bridge> bridgeSource,
            BridgeBuilderConfig builderConfig,
            Transform placeForBridge,
            Coroutines coroutines,
            IInputHandler input,
            Character.Character character)
        {
            _bridgeSource = bridgeSource;
            _builderConfig = builderConfig;
            _placeForBridge = placeForBridge;
            _coroutines = coroutines;
            _input = input;
            _character = character;
        }

        private Bridge CurrentBridge
        {
            get
            {
                if (_currentBridge != null) return _currentBridge;
                _currentBridge = _bridgeSource.Get();
                _currentBridge.ScaledTransform.rotation = new Quaternion(0, 0, 0, 0);
                _currentBridge.ScaledTransform.localScale = new Vector3(1, 1, 1);
                
                _currentBridge.transform.position = _placeForBridge.position;
                _currentBridge.gameObject.SetActive(true);

                return _currentBridge;
            }
        }
        
        public Bridge ComplitedBridge { get => _completedBridge; }

        public void Start()
        {
            _input.Pressed += StartBuild;
            _input.EndPressing += BuildComplete;
        }
        
        private void StartBuild()
        {
            _character.Animator.PlayAnimation(CharacterAnimationNames.ActiveWait);
            
            if (CurrentBridge.ScaledTransform.localScale.y < _builderConfig.MaxHeight)
            {
                var buildSpeed = _builderConfig.BuildSpeed * Time.deltaTime;
                CurrentBridge.ScaledTransform.localScale += new Vector3(0, buildSpeed, 0);
            }
            else
            {
                BuildComplete();
            }
        }

        public void BuildComplete()
        {
            _input.Pressed -= StartBuild;
            _input.EndPressing -= BuildComplete;

            _character.Animator.PlayAnimation(CharacterAnimationNames.Idle);

            _completedBridge = _currentBridge;
            _coroutines.StartCoroutine(BridgeFall());

            _currentBridge = null;
        }

        public IEnumerator BridgeFall()
        {
            var fallAngle = _completedBridge.ScaledTransform.rotation.eulerAngles + new Vector3(0, 0, -90);
            
            yield return _completedBridge.ScaledTransform
                .DORotate(fallAngle, _builderConfig.FallDuration)
                .WaitForCompletion();
            
            BuildCompleted?.Invoke();
        }
    }
}