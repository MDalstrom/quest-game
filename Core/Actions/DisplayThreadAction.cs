using QuestGame.Core.Interfaces;
using QuestGame.Core.Players;
using QuestGame.Core.Actions.Abstracts;
using System.Linq;

namespace QuestGame.Core.Actions
{
    public class DisplayThreadAction : ActionsList
    {
        public DisplayThreadAction(string title, params string[] messages) : base(title)
        {
            actions = messages.Select(x => new DisplayMessageAction("", x) as IAction).ToList();
        }
    }
}