namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public interface IGameState
    {
        public void Enter();
        public void Update();
        public void Exit();
    }
}