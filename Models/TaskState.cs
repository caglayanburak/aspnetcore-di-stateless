using Stateless;

namespace WebApiStatelessSample
{
    public class TaskState : ITaskState
    {
        private IPickingStateConfiguration _pickingConfiguration;
        private ISortingStateConfiguration _sortingConfiguration;
        private IPackingStateConfiguration _packingConfiguration;
        private ILoadingStateConfiguration _loadingConfiguration;
        public TaskState(PickingConfiguration pickingConfiguration, SortingConfiguration sortingConfiguration, PackingConfiguration packingConfiguration, LoadingConfiguration loadingConfiguration)
        {
            _pickingConfiguration = pickingConfiguration;
            _sortingConfiguration = sortingConfiguration;
            _packingConfiguration = packingConfiguration;
            _loadingConfiguration = loadingConfiguration;
        }
        private StateMachine<State, Trigger> _stateMachine;

        public void Configure(bool isSingle, State initialState = default(State))
        {
            _stateMachine = new StateMachine<State, Trigger>(initialState);
            _pickingConfiguration.Execute(_stateMachine, true);
            _sortingConfiguration.Execute(_stateMachine, true);
            _packingConfiguration.Execute(_stateMachine, true);
            _loadingConfiguration.Execute(_stateMachine, true);
        }

        State ITaskState.State { get => _stateMachine.State; }

        public void ChangeTo(Trigger trigger)
        {
            _stateMachine.Fire(trigger);
        }
    }
}