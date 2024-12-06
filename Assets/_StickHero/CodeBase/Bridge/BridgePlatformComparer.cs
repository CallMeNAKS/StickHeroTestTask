using CodeBase.Platform;

namespace CodeBase.Bridge
{
    public class BridgePlatformComparer
    {
        private readonly BridgeBuilder _bridgeBuilder;
        private readonly PlatformBuilder _platformBuilder;

        private const float OFFSET = 0.2f;

        public BridgePlatformComparer(BridgeBuilder bridgeBuilder,
            PlatformBuilder platformBuilder)
        {
            _bridgeBuilder = bridgeBuilder;
            _platformBuilder = platformBuilder;
        }

        public bool Compare()
        {
            var maxX = _platformBuilder.CurrentPlatform.MaxX;
            var minX = _platformBuilder.CurrentPlatform.MinX - OFFSET;

            var bridgeEnd = _bridgeBuilder.ComplitedBridge.EndPoint.x;

            if (bridgeEnd >= minX && bridgeEnd <= maxX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}