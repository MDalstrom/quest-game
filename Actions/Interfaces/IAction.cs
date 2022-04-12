using QuestGame.Players;

namespace QuestGame.Actions.Interfaces
{
    public interface IAction
    {
        void Do(IPlayer player);
    }
}
