using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.States.StatesInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
    internal class BootstrapState : IState
    {
        private readonly IGameStateMachine  _gameStateMachine;
        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class LoadLevelState : IState
    {
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
    
    internal class EnterLevelState : IState
    {
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class LoopLevelState : IState
    {
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}