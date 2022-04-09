using QuestGame.Core.Interfaces;
using System.Collections.Generic;

namespace QuestGame.Core.Actions.Abstracts
{
    public class ActionsList : BaseAction
    {
        protected List<IAction> actions;
        private int index = -1;

        public ActionsList(string title, List<IAction> actions) : base(title) { }

        public override IAction Do(string arg, out IPlayable result)
        {
            index++;
            var extraAction = actions[index].Do(arg, out result);

            if (index == actions.Count - 1) return null;

            return extraAction == null ? this : extraAction;
        }

        private void Reset()
        {
            index = -1;
        }
    }
}
