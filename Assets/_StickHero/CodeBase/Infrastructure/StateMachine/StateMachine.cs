using System.Collections.Generic;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine
{
    public abstract class StateMachine<TStateName, TState> : IInitializable where TState : class, IState
    {
        private Dictionary<TStateName, TState> _registeredStates = new();
        private TState _currentState;

        public TState ChangeState(TStateName stateName)
        {
            if (_registeredStates[stateName] == _currentState) return _currentState;

            TState newState = _registeredStates[stateName];

            _currentState?.Exit();
            newState.Enter();
            _currentState = newState;

            return _currentState;
        }

        public void RegisterState(TStateName stateName, TState state)
        {
            _registeredStates[stateName] = state;
        }

        public abstract void Initialize();
    }
}