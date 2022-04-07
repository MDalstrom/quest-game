using QuestGame.Core.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace QuestGame.Core
{
    public class Player
    {
        private static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null) instance = new Player();
                return instance;
            }
        }

        public IAction EntryPoint;

        private Player() { }

        public void Play(IAction subject)
        {
            var nextAction = subject.Do(out var content);
            Show(content);
            if (nextAction != null) Play(nextAction);
            else Play(EntryPoint);
        }

        private string Show(IPlayable subject)
        {
            Console.Clear();
            Console.WriteLine(subject.Content);
            return Console.ReadLine();
        }
    }
}
