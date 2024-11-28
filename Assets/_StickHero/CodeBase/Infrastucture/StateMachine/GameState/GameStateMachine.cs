using System.Collections.Generic;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public enum GameState
    {
        Start,
        Play,
        Lose
    }

    public class GameStateMachine
    {
        private Dictionary<GameState, IGameState> _states = new();
        private IGameState _currentState;

        public void ChangeState(IGameState newState)
        {
            if (_currentState == newState) return;
            
            _currentState.Exit();
            newState.Enter();
            _currentState = newState;
        }

        public void RegisterState(GameState stateType, IGameState state)
        {
            _states[stateType] = state;
        }
    }
}