using CodeBase.Infrastructure.StateMachine.GameState;
using CodeBase.Infrastructure.StateMachine.PlayState;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class StateInstaller : MonoInstaller
    {
        [SerializeField] private Platform.Platform _firstPlatform;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartState>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayState>().AsSingle().WithArguments(_firstPlatform);
            Container.BindInterfacesAndSelfTo<BuildState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProcessingState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoseState>().AsSingle();
        }
    }
}