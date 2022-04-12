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
        private readonly List<Room> rooms;

        public Room TargetRoom { get; set; }
        public IReadOnlyList<Room> Rooms => rooms;

        public RoomPlayer(List<Room> rooms) => this.rooms = rooms;
        public RoomPlayer(Room room) => rooms = new List<Room> { room };

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
            return result;
        }
    }
}
