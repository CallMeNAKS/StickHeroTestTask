using CodeBase.Bridge;
using CodeBase.Character;
using CodeBase.Infrastructure.CoroutineService;
using CodeBase.Infrastructure.GenericSource.ObjectPool;
using CodeBase.Infrastructure.Parallax;
using CodeBase.Infrastructure.ResetLogic;
using CodeBase.Input;
using CodeBase.Platform;
using CodeBase.Score;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class UIInstaller2 : Installer<UIInstaller2>
    {
        public override void InstallBindings()
        {
            throw new System.NotImplementedException();
        }
    }
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Platform.Platform _startPlatform;
        [SerializeField] private Transform _characterPoint;
        [SerializeField] private Transform _cameraStartPosition;

        [Header("Configs")] [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private PlatformConfig _platformConfig;
        [SerializeField] private BridgeBuilderConfig _bridgeBuilderConfig;
        [SerializeField] private CameraConfig _cameraConfig;

        [Header("Prefabs")] [SerializeField] private Character.Character _characterPrefab;
        [SerializeField] private Platform.Platform _platformPrefab;
        [SerializeField] private Bridge.Bridge _bridgePrefab;
        [SerializeField] private ParallaxEffect _parallaxEffect;

        public override void InstallBindings()
        {
            BindCharacter();
            BindCoroutines();
            BindRecycler();
            BindPlatformBuilder();
            BindBridgeBuilder();
            BindCameraMover();
            BindCharacterMover();
            BindInput();
            BindComparer();
            BindParallax();
            BindScoring();
        }

        private void BindScoring()
        {
            Container.Bind<Scoring>().AsSingle();
        }

        private void BindParallax()
        {
            Container.Bind<ParallaxEffect>().FromComponentInNewPrefab(_parallaxEffect).AsSingle().WithArguments(Camera.main).NonLazy();
        }

        private void BindRecycler()
        {
            Container.Bind<Recycling>().AsSingle();
        }

        private void BindComparer()
        {
            Container.Bind<BridgePlatformComparer>().AsSingle();
        }

        private void BindInput()
        {
            Container.Bind<IInputHandler>()
                .To<PCPlayerInput>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("[Input]")
                .AsSingle()
                .NonLazy();
        }
        
        private void BindCharacterMover()
        {
            Container.Bind<CharacterMover>()
                .AsSingle()
                .WithArguments(_characterConfig, _characterPoint);
        }

        private void BindCameraMover()
        {
            Container.Bind<CameraMover>()
                .AsSingle()
                .WithArguments(Camera.main, _cameraConfig);
        }

        private void BindBridgeBuilder()
        {
            var GenericSource = new GenericObjectPool<Bridge.Bridge>(_bridgePrefab, Container.Resolve<Recycling>());

            var bridgePoint = Container.Resolve<Character.Character>().BridgePoint;

            Container.Bind<BridgeBuilder>()
                .AsSingle()
                .WithArguments(GenericSource, _bridgeBuilderConfig, bridgePoint);
        }

        private void BindPlatformBuilder()
        {
            var GenericSource = new GenericObjectPool<Platform.Platform>(_platformPrefab, Container.Resolve<Recycling>());

            Container.Bind<PlatformBuilder>()
                .AsSingle()
                .WithArguments(_startPlatform, _platformConfig, GenericSource);
        }

        private void BindCoroutines()
        {
            Container.Bind<Coroutines>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("[Coroutine]")
                .AsSingle()
                .NonLazy();
        }

        private void BindCharacter()
        {
            Container.Bind<Character.Character>()
                .FromComponentInNewPrefab(_characterPrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}