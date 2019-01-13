using System;
using Stateless;

namespace WebApiStatelessSample
{
    public class LoadingConfiguration : ConfigurationStrategy
    {
        public override void Execute(StateMachine<State, Trigger> stateMachine, bool isSingle = true)
        {
            IsSingle = isSingle;
            StateMachine = stateMachine;

            stateMachine.Configure(State.Loading)
                .Ignore(Trigger.Move);
        }

        public bool IsSingle { get; set; }
        public StateMachine<State, Trigger> StateMachine { get; set; }

        public override void OnEntry(string message)
        {
            Console.WriteLine($"OnEntry {message}");
        }

        public override void OnExit(string message)
        {
            Console.WriteLine($"OnExit {message}");
        }
    }
}