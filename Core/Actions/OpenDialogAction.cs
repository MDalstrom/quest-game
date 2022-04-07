using QuestGame.Core.Actions.Abstracts;
using QuestGame.Core.Interfaces;
using QuestGame.Core.Actions.Utils;
using System.Linq;

namespace QuestGame.Core.Actions
{
    public class OpenDialogAction : DisplayMessageAction
    {
        private const string selectionPhrase = "Введите номер действия, чтобы совершить его: \r\n";
        private const string selectionLine = "{0}. {1}\r\n";

        private readonly IAction[] selections;

        public OpenDialogAction(string title, IAction[] selections) : base(title, selections.ToMessage(selectionPhrase, selectionLine)) 
        {
            this.selections = selections;
        }

        public override IAction Do(string arg, out IPlayable result)
        {
            base.Do(arg, out result);
            if (int.TryParse(arg, out var index) && index < selections.Length)
            {
                return selections[index];
            }
            else
            {
                return this;
            }
        }
    }
}
