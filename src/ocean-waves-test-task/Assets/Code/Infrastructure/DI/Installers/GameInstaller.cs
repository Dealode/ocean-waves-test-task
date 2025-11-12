using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Services.Coroutines;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.DI.Installers
{
    public class GameInstaller : IInstaller
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public GameInstaller(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void Install(IContainerBuilder builder)
        {
            BindInfrastructureServices(builder);
            BindCommonService(builder);
            BindStateMachine(builder);

            builder.RegisterBuildCallback(OnBuildComplete);
        }

        private void BindInfrastructureServices(IContainerBuilder builder) => 
            builder.RegisterInstance(_coroutineRunner);

        private void BindCommonService(IContainerBuilder builder) => 
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);

        private void BindStateMachine(IContainerBuilder builder)
        {
            builder.Register<IStateFactory, StateFactory>(Lifetime.Singleton);
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
        }

        private void OnBuildComplete(IObjectResolver container)
        {
            IStateFactory stateFactory = container.Resolve<IStateFactory>();
            IGameStateMachine gameStateMachine = container.Resolve<IGameStateMachine>();

            gameStateMachine.RegisterState(stateFactory.Create<BootstrapState>());
            gameStateMachine.RegisterState(stateFactory.Create<LoadLevelState>());
            gameStateMachine.RegisterState(stateFactory.Create<EnterLevelState>());
            gameStateMachine.RegisterState(stateFactory.Create<LoopLevelState>());
        }
    }
}