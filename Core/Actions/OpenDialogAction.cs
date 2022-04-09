using QuestGame.Core.Actions.Abstracts;
using QuestGame.Core.Interfaces;
using QuestGame.Core.Actions.Utils;
using QuestGame.Core.Players;
using System.Linq;
using System.Collections.Generic;

namespace QuestGame.Core.Actions
{
    public class OpenDialogAction : DisplayMessageAction
    {
        private const string selectionPhrase = "Введите номер действия, чтобы совершить его: \r\n";
        private const string selectionLine = "{0}. {1}\r\n";

        private readonly List<IAction> selections;

        public OpenDialogAction(string title, List<IAction> selections) : base(title, selections.ToMessage(selectionPhrase, selectionLine)) 
        {
            this.selections = selections;
        }

        public override IAction Do(string arg, out IPlayable result)
        {
            if (int.TryParse(arg, out var index) && index < selections.Count)
            {
                result = new EmptyMessage();
                return selections[index];
            }
            else
            {
                base.Do(arg, out result);
                return this;
            }
        }
    }
}
