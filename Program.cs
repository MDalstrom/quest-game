using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using QuestGame.Actions;
using QuestGame.Entities.Models;
using QuestGame.Players;

namespace QuestGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var testData = File.ReadAllText("e://kill-me/quest-game/Data/brawl-test.json");
            var subject = JsonSerializer.Deserialize<Room>(testData);

            var player = new RoomPlayer(subject);
            player.Play();
        }
    }
}
