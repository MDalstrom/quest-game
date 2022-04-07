using QuestGame.Core.Interfaces;
using QuestGame.Core.Actions.Abstracts;
using QuestGame.Core.Players;

namespace QuestGame.Core.Actions
{
    public class DisplayMessageAction : BaseAction
    {
        private BaseMessage message;

        public DisplayMessageAction(string title, string message) : base(title)
        {
            this.message = new BaseMessage(message);
        }

        public override IAction Do(out IPlayable result)
        {
            result = message;
            return null;
        }
    }
}
