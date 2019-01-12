using System;
using Stateless;

namespace WebApiStatelessSample
{
    public class PackingConfiguration : ConfigurationStrategy, IPackingStateConfiguration
    {
        public override void Execute(StateMachine<State, Trigger> stateMachine, bool isSingle = true)
        {
            IsSingle = isSingle;
            StateMachine = stateMachine;

            stateMachine.Configure(State.Packing)
                .Permit(Trigger.Move, State.Loading)
                .OnExit(x => OnExit("packing exit"))
                 .OnEntry(x => OnEntry("packing entry"));
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