using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.States.StatesInfrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    internal class BootstrapState : IState
    {
        private readonly IGameStateMachine  _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter() => 
            _gameStateMachine.Enter<LoadLevelState>();

        public void Exit() { }
    }

    internal class EnterLevelState : IState
    {
        public void Enter()
        {
            Debug.Log("Entering level state");
        }

        public void Exit()
        {
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