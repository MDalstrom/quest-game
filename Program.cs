using System;
using QuestGame.Core;
using QuestGame.Core.Actions;
using QuestGame.Core.Interfaces;

namespace QuestGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var actions = new IAction[3] {
                new DisplayMessageAction("вывести сообщение 1", "сообщение 1"),
                new DisplayMessageAction("вывести сообщение 2", "сообщение 2"),
                new DisplayMessageAction("вывести сообщение 3", "сообщение 3")
                };

            Player.Instance.Play(new OpenDialogAction(
                "dialog",
                actions
                ));
        }
    }
}
