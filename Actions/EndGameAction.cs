using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestGame.Players;

namespace QuestGame.Actions
{
    public class EndGameAction : ShowTextAction
    {
        private const string endGameMessage = "Игра окончена.";
        public EndGameAction() : base(endGameMessage) { }

        public override void Do(IPlayer player)
        {
            while (true)
            {
                base.Do(player);
            }
        }
    }
}
