using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine.GameState;
using CodeBase.Infrastructure.StateMachine.PlayState;
using Unity.VisualScripting;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public enum GameStateName
    {
        Start,
        Play,
        Build,
        Move,
        Processing,
        Lose
    }

    public class GameStateMachine : StateMachine<GameStateName, IGameState>
    {
        private readonly StateFactory _stateFactory;

        public GameStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public override void Initialize()
        { 
            RegisterState(GameStateName.Start, _stateFactory.CreateState<StartState>());
            RegisterState(GameStateName.Play, _stateFactory.CreateState<PlayState>());
            RegisterState(GameStateName.Build, _stateFactory.CreateState<BuildState>());
            RegisterState(GameStateName.Move, _stateFactory.CreateState<MoveState>());
            RegisterState(GameStateName.Processing, _stateFactory.CreateState<ProcessingState>());
            RegisterState(GameStateName.Lose, _stateFactory.CreateState<LoseState>());

            this.ChangeState(GameStateName.Start);
        }
    }
}