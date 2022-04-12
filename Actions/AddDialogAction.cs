using QuestGame.Actions.Interfaces;
using QuestGame.Entities.Models;
using QuestGame.Players;
using System.Linq;

namespace QuestGame.Actions
{
    public class AddDialogAction : IAction
    {
        public string RoomName { get; set; }
        public string CharacterName { get; set; }
        public Dialog Dialog { get; set; }

        public AddDialogAction(string roomName, string characterName, Dialog dialog)
        {
            RoomName = roomName;
            CharacterName = characterName;
            Dialog = dialog;
        }

        public void Do(IPlayer player)
        {
            if (player is RoomPlayer roomPlayer)
            {
                var character = roomPlayer
                    .Rooms.First(x => x.Title == RoomName)
                    .Characters.First(x => x.Name == CharacterName);
                character.Dialogs.Add(Dialog);
            }
        }
    }
}
