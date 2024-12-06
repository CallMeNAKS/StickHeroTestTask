using CodeBase.Infrastructure.GenericSource;
using CodeBase.Infrastructure.ResetLogic;
using UnityEngine;

namespace CodeBase.Platform
{
    public class PlatformBuilder
    {
        private readonly GenericSource<Platform> _platformSource;
        private readonly PlatformConfig _platformConfig;
        private readonly Platform _startPlatform;
        
        private Platform _currentPlatform;

        public PlatformBuilder(Platform startPlatform,
            GenericSource<Platform> platformSource,
            PlatformConfig platformConfig)
        {
            _startPlatform = startPlatform;
            _currentPlatform = startPlatform;
            _platformSource = platformSource;
            _platformConfig = platformConfig;
        }
        
        public Platform CurrentPlatform => _currentPlatform;

        public Platform Build()
        {
            var size = Random.Range(_platformConfig.MinSize, _platformConfig.MaxSize);
            var range = Random.Range(_platformConfig.MinRange, _platformConfig.MaxRange);
            var placeForPlatform = CalculatePlatformPosition(size, range);

            var newPlatform = CreatePlatform(placeForPlatform, size);

            _currentPlatform = newPlatform;
            return _currentPlatform;
        }

        private Vector3 CalculatePlatformPosition(float platformSize, float range)
        {
            float currentPlatformRightEdge = _currentPlatform.MaxX;
            float newPlatformLeftEdge = currentPlatformRightEdge + range;
            float newPlatformCenterX = newPlatformLeftEdge + platformSize / 2;

            return new Vector3(newPlatformCenterX, _currentPlatform.transform.position.y,
                _currentPlatform.transform.position.z);
        }


        private Platform CreatePlatform(Vector3 position, float platformSize)
        {
            var newPlatform = _platformSource.Get();
            newPlatform.gameObject.SetActive(true);
            
            newPlatform.transform.position = position;
            newPlatform.PlatformTransform.localScale =
                new Vector2(platformSize, newPlatform.PlatformTransform.localScale.y);
            return newPlatform;
        }

        public void Reset()
        {
            _currentPlatform = _startPlatform;
        }
    }
}