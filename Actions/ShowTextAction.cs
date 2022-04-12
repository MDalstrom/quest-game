using System;
using QuestGame.Actions.Abstracts;
using QuestGame.Players;

namespace QuestGame.Actions
{
    public class ShowTextAction : BaseAction
    {
        protected string message;
        public ShowTextAction(string message) { this.message = message; }

        public override void Do(IPlayer player)
        {
            Console.WriteLine(message);
            base.Do(player);
        }
    }
}
