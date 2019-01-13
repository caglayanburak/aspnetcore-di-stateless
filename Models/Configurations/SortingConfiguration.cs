using System;
using Stateless;

namespace WebApiStatelessSample
{
    public class SortingConfiguration : ConfigurationStrategy
    {
        public override void Execute(StateMachine<State, Trigger> stateMachine, bool isSingle)
        {
            IsSingle = isSingle;
            StateMachine = stateMachine;

            stateMachine.Configure(State.Sorting)
                .Permit(Trigger.Move, State.Packing)
                .OnExit(x => OnExit("sorting exit"))
                 .OnEntry(x => OnEntry("sorting entry"));
        }

        private bool IsSingle { get; set; }
        private StateMachine<State, Trigger> StateMachine { get; set; }

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