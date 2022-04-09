using QuestGame.Core.Interfaces;
using QuestGame.Core.Players;
using QuestGame.Entities;
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

        private string lastResponse;
        public IAction EntryPoint { get; set; }

        private Player() { }

        public void Play(Room subject)
        {
            EntryPoint = subject.GetMenu();
            Play(EntryPoint);
        }
        public void Play(IAction subject)
        {
            var nextAction = subject.Do(lastResponse, out var content);
            lastResponse = Show(content);

            if (nextAction != null)
            {
                Play(nextAction);
            }
            else
            {
                if (EntryPoint == null)
                {
                    return;
                }
                else
                {
                    Play(EntryPoint);
                }
            }
        }

        private string Show(IPlayable subject)
        {
            Console.Clear();

            if (subject is EmptyMessage) return null;

            Console.WriteLine(subject.Content);
            return Console.ReadLine();
        }
    }
}
