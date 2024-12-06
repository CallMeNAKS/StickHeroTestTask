using System;
using CodeBase.Infrastructure.Parallax;
using CodeBase.Infrastructure.ResetLogic;
using CodeBase.Input;
using CodeBase.Platform;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public class LoseState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoseView _loseView;
        private readonly IInputHandler _inputHandler;
        private readonly Recycling _recycling;
        private readonly CameraMover _cameraMover;
        private readonly PlatformBuilder _platformBuilder;
        private readonly ParallaxEffect _parallaxEffect;

        public LoseState(GameStateMachine gameStateMachine,
            LoseView loseView,
            IInputHandler inputHandler,
            Recycling recycling,
            CameraMover cameraMover,
            PlatformBuilder platformBuilder,
            ParallaxEffect parallaxEffect)
        {
            _gameStateMachine  = gameStateMachine;
            _loseView = loseView;
            _inputHandler  = inputHandler;
            _recycling = recycling;
            _cameraMover = cameraMover;
            _platformBuilder = platformBuilder;
            _parallaxEffect = parallaxEffect;
        }
        
        public void Enter()
        {
            _loseView.ShowUI();
            _inputHandler.Clicked += ChangeState;
        }

        private void ChangeState()
        {
            _gameStateMachine.ChangeState(GameStateName.Start);
        }

        public void Update()
        {
            Debug.Log("Lose upd");
        }

        public void Exit()
        {
            _inputHandler.Clicked -= ChangeState;
            _loseView.HideUI();
            _recycling.Clear();
            _cameraMover.ResetCamera();
            _platformBuilder.Reset();
            _parallaxEffect.ResetParallax();
        }
    }
}