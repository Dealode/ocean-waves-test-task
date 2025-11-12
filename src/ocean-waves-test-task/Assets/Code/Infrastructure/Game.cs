using System;
using Code.Infrastructure.DI.Installers;
using VContainer.Unity;
using static UnityEngine.Object;

namespace Code.Infrastructure
{
    public class Game : IDisposable
    {
        private readonly LifetimeScope _gameRootScope;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _gameRootScope = LifetimeScope.Create(new GameInstaller(coroutineRunner), "GameRootScope");
            DontDestroyOnLoad(_gameRootScope);
        }

        public void Start()
        {
        }
        //_gameRootScope.Container.Resolve<GameStateMachine>().Enter<BootstrapState>();

        public void Dispose() => 
            _gameRootScope.Dispose();
    }

    public interface ICoroutineRunner
    {
    }
}