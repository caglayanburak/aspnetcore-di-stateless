using System;
using Stateless;

namespace WebApiStatelessSample
{
    public abstract class ConfigurationStrategy : IStateConfiguration
    {
        public abstract void Execute(StateMachine<State, Trigger> stateMachine, bool isSingle);
        public abstract void OnEntry(string message);
        public abstract void OnExit(string message);
    }
}