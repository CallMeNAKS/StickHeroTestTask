using CodeBase.Input;

namespace CodeBase.Infrastructure.StateMachine.GameState
{
    public class GameLoop
    {
        private GameStateMachine _gameStateMachine;
        private IInputHandler _input;
        // private Character _character;

        public GameLoop(GameStateMachine gameStateMachine, IInputHandler input)
        {
            _gameStateMachine = gameStateMachine;
            _input = input;
        }
    }
}