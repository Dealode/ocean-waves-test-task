using System;
using System.Collections.Generic;
using Code.Infrastructure.States.StatesInfrastructure;

namespace Code.Infrastructure.States.StateMachine
{
    internal class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _registeredStates = new();
        private IExitableState _activeState;

        public void RegisterState<T>(T state) where T : class, IExitableState => 
            _registeredStates.Add(typeof(T), state);
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
      
            TState state = GetState<TState>();
            _activeState = state;
      
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _registeredStates[typeof(TState)] as TState;
    }
}