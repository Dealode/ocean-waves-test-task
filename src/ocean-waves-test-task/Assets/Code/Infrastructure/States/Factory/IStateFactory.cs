using Code.Infrastructure.States.StatesInfrastructure;

namespace Code.Infrastructure.States.Factory
{
    internal interface IStateFactory
    {
        T Create<T>() where T : class, IExitableState;
    }
}