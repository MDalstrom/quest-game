using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Actions.Interfaces;
using QuestGame.Entities.Models;
using QuestGame.Players;

namespace QuestGame.Actions
{
    public class TransferItemsAction : IAction
    {
        public string RoomName { get; set; }
        public string CharacterFrom { get; set; }
        public string CharacterTo { get; set; }
        public List<Item> Items { get; set; }

        public TransferItemsAction(string roomName, string characterFrom, string characterTo, List<Item> items)
        {
            RoomName = roomName;
            CharacterFrom = characterFrom;
            CharacterTo = characterTo;
            Items = items;
        }


        public void Do(IPlayer player)
        {
            if (Items == null || Items.Count == 0) return;

            if (player is RoomPlayer roomPlayer)
            {
                var room = roomPlayer.Rooms.FirstOrDefault(x => x.Title == RoomName);
                var from = CharacterFrom == "player" ? roomPlayer.Inventory : room.Characters.FirstOrDefault(x => x.Name == CharacterFrom).Inventory;
                var to = CharacterTo == "player" ? roomPlayer.Inventory : room.Characters.FirstOrDefault(x => x.Name == CharacterTo).Inventory;

                if (Items[0].Title == "all") from.TransferAllTo(to);
                else Items.ForEach(x => from.TryTransferTo(to, x));
            }
        }
    }
}
