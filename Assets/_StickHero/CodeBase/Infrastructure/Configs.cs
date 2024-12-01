using CodeBase.Bridge;
using CodeBase.Character;
using CodeBase.Platform;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public static class Configs
    {
        public static readonly PlatformConfig Platform = Resources.Load<PlatformConfig>("Configs/PlatformConfig");
        public static readonly CharacterConfig Character = Resources.Load<CharacterConfig>("Configs/CharacterConfig");
        public static readonly BridgeBuilderConfig Bridge = Resources.Load<BridgeBuilderConfig>("Configs/BridgeConfig");
        public static readonly CameraConfig Camera = Resources.Load<CameraConfig>("Configs/CameraConfig");
    }
}