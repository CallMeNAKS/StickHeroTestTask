using System;
using System.Collections;
using CodeBase.Bridge;
using CodeBase.Character;
using CodeBase.Infrastructure.CoroutineService;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public class MoveState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly CharacterMover _characterMover;
        private readonly BridgeBuilder _bridgeBuilder;
        private readonly Coroutines _coroutines;

        private Coroutine _moveCoroutine;

        public MoveState(GameStateMachine gameStateMachine,
            CharacterMover characterMover,
            BridgeBuilder bridgeBuilder,
            Coroutines coroutines )
        {
            _gameStateMachine = gameStateMachine;
            _characterMover = characterMover;
            _bridgeBuilder = bridgeBuilder;
            _coroutines = coroutines;
        }

        public void Enter()
        {
            _moveCoroutine = _coroutines.StartCoroutine(
                Move(_bridgeBuilder.ComplitedBridge.EndPoint));
        }

        private IEnumerator Move(Vector2 endPosition)
        {
            yield return _coroutines.StartCoroutine(_characterMover.Move(endPosition));
            _gameStateMachine.ChangeState(GameStateName.Processing);
        }

        public void Exit()
        {
            _coroutines.StopCoroutine(_moveCoroutine);
        }
    }
}