using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [Header("UI Prefabs")]
        [SerializeField] private StartView _startView;
        [SerializeField] private PlayView _playView;
        [SerializeField] private LoseView _loseView;

        public override void InstallBindings()
        {
            BindStartView();
            BindPlayView();
            BindLoseView();
        }

        private void BindLoseView()
        {
            Container.Bind<LoseView>()
                .FromComponentInNewPrefab(_loseView)
                .WithGameObjectName("[LoseView]")
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayView()
        {
            Container.Bind<PlayView>()
                .FromComponentInNewPrefab(_playView)
                .WithGameObjectName("[PlayView]")
                .AsSingle()
                .NonLazy();
        }

        private void BindStartView()
        {
            Container.Bind<StartView>()
                .FromComponentInNewPrefab(_startView)
                .WithGameObjectName("[StartView]")
                .AsSingle()
                .NonLazy();
        }
    }
}