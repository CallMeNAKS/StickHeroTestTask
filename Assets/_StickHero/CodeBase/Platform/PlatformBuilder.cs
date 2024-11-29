using CodeBase.Infrastructure.GenericSource;
using UnityEngine;

namespace CodeBase.Platform
{
    public class PlatformBuilder
    {
        private Transform _currentPlatformTransform;
        private readonly GenericSource<Platform> _platformSource;
        private readonly PlatformConfig _platformConfig;

        public PlatformBuilder(Transform currentPlatformTransform,
            GenericSource<Platform> platformSource,
            PlatformConfig platformConfig)
        {
            _currentPlatformTransform = currentPlatformTransform;
            _platformSource = platformSource;
            _platformConfig = platformConfig;
        }

        public void Build()
        {
            var size = Random.Range(_platformConfig.MinSize, _platformConfig.MaxSize);
            var range = Random.Range(_platformConfig.MinRange, _platformConfig.MaxRange);
            var placeForPlatform = CalculatePlatformPosition(size, range);

            var newPlatform = CreatePlatform(placeForPlatform, size);
            
            _currentPlatformTransform = newPlatform.transform;
        }

        private Vector3 CalculatePlatformPosition(float platformSize, float range)
        {
            var currentPlatformWidth = _currentPlatformTransform.localScale.x;
            return _currentPlatformTransform.position + 
                   new Vector3(currentPlatformWidth / 2 + range + platformSize / 2, 0, 0);
        }

        private Platform CreatePlatform(Vector3 position, float platformSize)
        {
            var newPlatform = _platformSource.Get();
            newPlatform.transform.position = position;
            newPlatform.PlatformTransform.localScale = 
                new Vector2(platformSize, newPlatform.PlatformTransform.localScale.y);
            return newPlatform;
        }
    }
}