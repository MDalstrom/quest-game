using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Entities.Models;
using QuestGame.Actions;
using QuestGame.Actions.Interfaces;

namespace QuestGame.Players
{
    public class RoomPlayer : IPlayer
    {
        private const string callDescription = "Осмотреть комнату {0}";
        private const string callInventory = "Просмотреть свой инвентарь";
        private readonly List<Room> rooms;

        public Room TargetRoom { get; set; }
        public IReadOnlyList<Room> Rooms => rooms;
        public Inventory Inventory { get; }

        public RoomPlayer(List<Room> rooms)
        {
            this.rooms = rooms;
            Inventory = new Inventory();
        }
        public RoomPlayer(Room room) : this(new List<Room> { room }) { }

        public void Play()
        {
            if (TargetRoom == null) TargetRoom = rooms[0];

            new ShowSelectionMenuAction(GetDialogs()).Do(this);

            Play();
        }

        private List<Dialog> GetDialogs()
        {
            var result = TargetRoom.Characters.SelectMany(x => x.Dialogs).ToList();
            result.Add(new Dialog { 
                Title = string.Format(callDescription, TargetRoom.Title),
                Actions = new List<IAction> { new ShowTextAction(TargetRoom.Description) }
                });
            result.Add(new Dialog { 
                Title = callInventory,
                Actions = new List<IAction> { new ShowInventoryAction(Inventory) }
            });
            return result;
        }
    }
}
