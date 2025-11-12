using Code.Infrastructure.States.StatesInfrastructure;

namespace Code.Infrastructure.States.StateMachine
{
    internal interface IGameStateMachine
    {
        void RegisterState<T>(T state) where T : class, IExitableState;
        void Enter<TState>() where TState : class, IState;
    }
}