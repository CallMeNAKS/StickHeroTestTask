using System;
using System.Collections;
using CodeBase.Character;
using CodeBase.Infrastructure.CoroutineService;
using CodeBase.Infrastructure.StateMachine.PlayState;
using CodeBase.Platform;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public class PlayState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayView _playView;
        private readonly CameraMover _cameraMover;
        private readonly CharacterMover _characterMover;
        private readonly PlatformBuilder _platformBuilder;
        private readonly Coroutines _coroutines;

        private Platform.Platform _startPlatform;
        private Coroutine _playCoroutine;

        public PlayState(
            GameStateMachine gameStateMachine,
            PlayView playView,
            CameraMover cameraMover,
            CharacterMover characterMover,
            PlatformBuilder platformBuilder,
            Coroutines coroutines,
            Platform.Platform startPlatform
        )
        {
            _gameStateMachine = gameStateMachine;
            _playView = playView;
            _cameraMover = cameraMover;
            _characterMover = characterMover;
            _platformBuilder = platformBuilder;
            _coroutines = coroutines;
            _startPlatform = startPlatform;
        }

        public void Enter()
        {
            _playView.ShowUI();
            _playCoroutine = _coroutines.StartCoroutine(EnterRoutine());
        }

        private IEnumerator EnterRoutine()
        {
            yield return _cameraMover.ScaleCamera();
            _cameraMover.MoveToPlatform(_startPlatform);

            var placeToMove = new Vector2(_startPlatform.MaxX - 0.3f, _startPlatform.MaxY); //TODO Вынести 
            
            yield return  _coroutines.StartCoroutine(_characterMover.Move(placeToMove));

            _platformBuilder.Build();

            _gameStateMachine.ChangeState(GameStateName.Build);
        }

        public void Exit()
        {
            _coroutines.StopCoroutine(_playCoroutine);
        }
    }
}