using Code.Infrastructure.DI.Extensions;
using Code.Infrastructure.States.StatesInfrastructure;
using VContainer;

namespace Code.Infrastructure.States.Factory
{
    internal class StateFactory : IStateFactory
    {
        private readonly IObjectResolver _container;

        public StateFactory(IObjectResolver container) => 
            _container = container;

        public T Create<T>() where T : class, IExitableState => 
            _container.Instantiate<T>();
    }
}