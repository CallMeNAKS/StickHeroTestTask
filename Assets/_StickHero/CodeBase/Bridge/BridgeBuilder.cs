using System;
using CodeBase.Infrastructure.GenericSource;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Bridge
{
    public class BridgeBuilder
    {
        private readonly GenericSource<Bridge> _bridgeSource;
        private readonly BridgeBuilderConfig _builderConfig;
        private readonly Transform _placeForBridge;

        private Bridge _currentBridge;
        private bool _isOutgrown;
        
        public event Action BuildCompleted;

        public BridgeBuilder(GenericSource<Bridge> bridgeSource,
            BridgeBuilderConfig builderConfig,
            Transform placeForBridge)
        {
            _bridgeSource = bridgeSource;
            _builderConfig = builderConfig;
            _placeForBridge = placeForBridge;
        }

        private Bridge CurrentBridge
        {
            get
            {
                if (_currentBridge != null) return _currentBridge;
                _currentBridge = _bridgeSource.Get();
                _currentBridge.transform.position = _placeForBridge.position;

                return _currentBridge;
            }
        }

        public void StartBuild()
        {
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
            CurrentBridge.ScaledTransform.DORotate(new Vector3(0, 0, -90), _builderConfig.FallSpeed);
            _currentBridge = null;
            BuildCompleted?.Invoke();
        }
    }
}