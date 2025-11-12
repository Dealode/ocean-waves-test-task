using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.States.StatesInfrastructure;
using VContainer.Unity;

namespace Code.Infrastructure.States.GameStates
{
    internal class LoadLevelState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly LifetimeScope  _lifetimeScope;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, LifetimeScope lifetimeScope)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _lifetimeScope = lifetimeScope;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene("MainScene", parent: _lifetimeScope, OnLoaded);
        }

        private void OnLoaded() => 
            _gameStateMachine.Enter<EnterLevelState>();

        public void Exit() { }
    }
}