using QuestGame.Core.Interfaces;

namespace QuestGame.Core.Actions.Abstracts
{
    public abstract class BaseAction : IAction
    {
        private string title;
        public string Title => title;

        public BaseAction(string title)
        {
            this.title = title;
        }

        public abstract IAction Do(string arg, out IPlayable result);
    }
}
