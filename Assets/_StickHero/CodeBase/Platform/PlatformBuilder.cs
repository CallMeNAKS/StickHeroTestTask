using CodeBase.Infrastructure.GenericSource;
using UnityEngine;

namespace CodeBase.Platform
{
    public class PlatformBuilder
    {
        private Platform _currentPlatform;
        private readonly GenericSource<Platform> _platformSource;
        private readonly PlatformConfig _platformConfig;

        public PlatformBuilder(Platform currentPlatform,
            GenericSource<Platform> platformSource,
            PlatformConfig platformConfig)
        {
            _currentPlatform = currentPlatform;
            _platformSource = platformSource;
            _platformConfig = platformConfig;
        }

        public void Build()
        {
            var size = Random.Range(_platformConfig.MinSize, _platformConfig.MaxSize);
            var range = Random.Range(_platformConfig.MinRange, _platformConfig.MaxRange);
            var placeForPlatform = CalculatePlatformPosition(size, range);

            var newPlatform = CreatePlatform(placeForPlatform, size);

            _currentPlatform = newPlatform;
        }

        private Vector3 CalculatePlatformPosition(float platformSize, float range)
        {
            var currentSpriteRenderer = _currentPlatform.SpriteRenderer;

            float currentPlatformRightEdge = currentSpriteRenderer.bounds.max.x;
            float newPlatformLeftEdge = currentPlatformRightEdge + range;
            float newPlatformCenterX = newPlatformLeftEdge + platformSize / 2;

            return new Vector3(newPlatformCenterX, _currentPlatform.transform.position.y,
                _currentPlatform.transform.position.z);
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