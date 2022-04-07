using QuestGame.Core.Actions.Abstracts;
using QuestGame.Core.Interfaces;

namespace QuestGame.Core.Actions
{
    public class FinishGameAction : DisplayMessageAction
    {
        private const string endPhrase = "Игра окончена.";

        public FinishGameAction(string title) : base(title, endPhrase) { }

        public override IAction Do(out IPlayable result)
        {
            base.Do(out result);
            return this;
        }
    }
}
