using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using QuestGame.Core;
using QuestGame.Core.Actions;
using QuestGame.Core.Interfaces;
using QuestGame.Entities;

namespace QuestGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var testData = File.ReadAllText("e://kill-me/quest-game/Data/brawl-test.json");
            var room = JsonSerializer.Deserialize<Room>(testData);

            //Player.Instance.Play(room);

            Console.ReadLine();
        }
    }
}
