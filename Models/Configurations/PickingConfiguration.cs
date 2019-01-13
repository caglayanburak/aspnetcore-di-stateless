using System;
using Stateless;

namespace WebApiStatelessSample
{
   public class PickingConfiguration : ConfigurationStrategy
    {
        public bool IsSingle { get; }
        private StateMachine<State, Trigger> StateMachine { get; set; }

        public override void OnEntry(string message)
        {
            Console.WriteLine($"OnEntry {message}");
        }

        public override void OnExit(string message)
        {
            Console.WriteLine($"OnExit {message}");
        }

        public override void Execute(StateMachine<State, Trigger> stateMachine, bool isSingle = true)
        {
            StateMachine = stateMachine;
            StateMachine.Configure(State.Picking)
                 .PermitIf(Trigger.Move, State.Sorting, () => !isSingle)
                 .PermitIf(Trigger.Move, State.Packing, () => isSingle)
                 .OnExit(x => OnExit("picking exit"))
                 .OnEntry(x => OnEntry("picking entry"));
        }
    }

}