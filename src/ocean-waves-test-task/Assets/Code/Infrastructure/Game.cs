using System;
using Code.Infrastructure.DI.Installers;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Services.Coroutines;
using VContainer;
using VContainer.Unity;
using static UnityEngine.Object;

namespace Code.Infrastructure
{
    public class Game : IDisposable
    {
        private readonly LifetimeScope _gameRootScope;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _gameRootScope = LifetimeScope.Create(installer: new GameInstaller(coroutineRunner), "GameRootScope");
            DontDestroyOnLoad(_gameRootScope);
        }

        public void Start() => 
            _gameRootScope.Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();

        public void Dispose() => 
            _gameRootScope.Dispose();
    }
}