using QuestGame.Players;
using QuestGame.Actions.Interfaces;
using System.Collections.Generic;

namespace QuestGame.Actions.Utils
{
    public static class ListActionsExtensions
    {
        public static void DoAll(this List<IAction> actions, IPlayer player)
        {
            actions.ForEach(x => x.Do(player));
        }
    }
}
