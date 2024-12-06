using System;
using System.Collections;
using CodeBase.Bridge;
using CodeBase.Character;
using CodeBase.Infrastructure.CoroutineService;
using CodeBase.Infrastructure.StateMachine.GameState;
using CodeBase.Platform;
using CodeBase.Score;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.PlayState
{
    public class ProcessingState : IGameState
    {
        private readonly BridgePlatformComparer _comparer;
        private readonly CharacterMover _characterMover;
        private readonly Coroutines _coroutines;
        private readonly PlatformBuilder _platformBuilder;
        private readonly CameraMover _cameraMover;
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayView _playView;
        private readonly Scoring _scoring;
        private readonly BridgeBuilder _bridgeBuilder;

        private Coroutine _processingCoroutine;

        private const float DEVIATION_CORRECTION = 0.4f;

        public ProcessingState(CharacterMover characterMover,
            Coroutines coroutines,
            BridgePlatformComparer comparer,
            PlatformBuilder platformBuilder,
            CameraMover cameraMover,
            GameStateMachine gameStateMachine,
            PlayView playView,
            Scoring scoring,
            BridgeBuilder bridgeBuilder)
        {
            _characterMover = characterMover;
            _coroutines = coroutines;
            _comparer = comparer;
            _platformBuilder = platformBuilder;
            _cameraMover = cameraMover;
            _gameStateMachine = gameStateMachine;
            _playView = playView;
            _scoring = scoring;
            _bridgeBuilder = bridgeBuilder;
        }

        public void Enter()
        {
            if (_comparer.Compare())
            {
                _processingCoroutine = _coroutines.StartCoroutine(Pass());
            }
            else
            {
                _processingCoroutine = _coroutines.StartCoroutine(Fall());
            }
        }

        private IEnumerator Pass()
        {
            _scoring.AddScore(1);
            
            var endPosition = new Vector2(_platformBuilder.CurrentPlatform.MaxX - DEVIATION_CORRECTION,
                _platformBuilder.CurrentPlatform.MaxY);// TODO вынести расчет 
            
            yield return _characterMover.Move(endPosition);

            var currentPlatform = _platformBuilder.CurrentPlatform;
            _cameraMover.MoveToPlatform(currentPlatform);

            _platformBuilder.Build();

            _gameStateMachine.ChangeState(GameStateName.Build);
        }

        private IEnumerator Fall()
        {
            _scoring.ResetScore();

            _coroutines.StartCoroutine(_bridgeBuilder.BridgeFall());
            yield return _characterMover.Fall();
            _playView.HideUI();        

            _gameStateMachine.ChangeState(GameStateName.Lose);
        }

        public void Exit()
        {
            _coroutines.StopCoroutine(_processingCoroutine);
        }
    }
}