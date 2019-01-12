namespace WebApiStatelessSample
{
    public interface ITaskState
    {
        void ChangeTo(Trigger trigger);
        State State { get; }
        void Configure(bool isSingle, State initialState = default(State));
    }
}