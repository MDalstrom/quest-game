using QuestGame.Core.Actions.Abstracts;
using QuestGame.Core.Interfaces;

namespace QuestGame.Core.Actions
{
    public class FinishGameAction : DisplayMessageAction
    {
        private const string endPhrase = "Игра окончена.";

        public FinishGameAction() : base(null, endPhrase) { }

        public override IAction Do(string arg, out IPlayable result)
        {
            base.Do(arg, out result);
            return this;
        }
    }
}
