using QuestGame.Core.Interfaces;
using System;

namespace QuestGame.Core.Actions.Abstracts
{
    public abstract class ActionsList : BaseAction
    {
        protected IAction[] actions;
        private int index = -1;

        public ActionsList(string title) : base(title) { }

        public override IAction Do(out IPlayable result)
        {
            index++;
            var extraAction = actions[index].Do(out result);

            if (index == actions.Length - 1) return null;

            return extraAction == null ? this : extraAction;
        }

        private void Reset()
        {
            index = -1;
        }
    }
}
