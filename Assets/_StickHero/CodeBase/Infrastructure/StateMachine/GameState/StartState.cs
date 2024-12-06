using System;
using CodeBase.Character;
using CodeBase.Input;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public class StartState : IGameState
    {
        private readonly StartView _startView;
        private readonly IInputHandler _inputHandler;
        private readonly CharacterMover _characterMover;
        private readonly GameStateMachine _gameStateMachine;

        public StartState(GameStateMachine gameStateMachine,
            StartView startView,
            IInputHandler inputHandler,
            CharacterMover characterMover)
        {
            _gameStateMachine  = gameStateMachine;
            _startView = startView;
            _inputHandler = inputHandler;
            _characterMover = characterMover;
        }

        public void Enter()
        {
            _characterMover.TeleportToStart();
            _startView.ShowUI();
            _inputHandler.Clicked += ChangeState;
        }

        private void ChangeState()
        {
            _gameStateMachine.ChangeState(GameStateName.Play);
        }

        public void Update()
        {
            Debug.Log("Start upd");
        }

        public void Exit()
        {
            _inputHandler.Clicked -= ChangeState;
            _startView.HideUI();
        }
    }
}