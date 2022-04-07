namespace QuestGame.Core.Interfaces
{
    public interface IAction
    {
        string Title { get; }
        IAction Do(out IPlayable result);
    }
}
