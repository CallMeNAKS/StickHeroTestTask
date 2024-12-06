using System;
using CodeBase.Bridge;
using CodeBase.Input;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public class BuildState : IGameState
    {
        private readonly BridgeBuilder _bridgeBuilder;
        private readonly GameStateMachine _stateMachine;

        public BuildState(GameStateMachine stateMachine,
            BridgeBuilder bridgeBuilder)
        {
            _stateMachine  = stateMachine;
            _bridgeBuilder = bridgeBuilder;
        }

        public void Enter()
        {
            SubscribeBuilder();
        }

        public void Exit()
        {
            UnSubscribeBuilder();
        }

        private void SubscribeBuilder()
        {
            _bridgeBuilder.BuildCompleted += OnComplete;
            _bridgeBuilder.Start();
        }

        private void UnSubscribeBuilder()
        {
            _bridgeBuilder.BuildCompleted -= OnComplete;
        }

        private void OnComplete()
        {
            _stateMachine.ChangeState(GameStateName.Move);
        }
    }
}