using Stateless;

namespace WebApiStatelessSample
{
   public interface IStateConfiguration
    {
        void Execute(StateMachine<State, Trigger> stateMachine, bool isSingle);
    }
}