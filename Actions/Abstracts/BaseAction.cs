using QuestGame.Actions.Interfaces;
using QuestGame.Players;
using System;

namespace QuestGame.Actions.Abstracts
{
    public abstract class BaseAction : IAction
    {
        public virtual void Do(IPlayer player)
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
