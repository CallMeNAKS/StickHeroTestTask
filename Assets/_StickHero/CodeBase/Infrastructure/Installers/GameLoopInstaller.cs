using CodeBase.Infrastructure.StateMachine.GameState;
using CodeBase.Infrastructure.StateMachine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class GameLoopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StateFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
    }
}