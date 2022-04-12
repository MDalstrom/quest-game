using QuestGame.Actions.Interfaces;
using QuestGame.Entities.Models;
using QuestGame.Players;
using System.Linq;
using System;

namespace QuestGame.Actions
{
    public class RemoveDialogAction : IAction
    {
        public string RoomName;
        public string CharacterName;
        public string DialogName;

        public RemoveDialogAction(string roomName, string characterName, string dialogName)
        {
            RoomName = roomName;
            CharacterName = characterName;
            DialogName = dialogName;
        }

        public void Do(IPlayer player)
        {
            if (player is RoomPlayer roomPlayer)
            {
                var character = roomPlayer
                    .Rooms.First(x => x.Title == RoomName)
                    .Characters.First(x => x.Name == CharacterName);
                character.Dialogs.Remove(character.Dialogs.First(x => x.Title == DialogName));
            }
        }
    }
}
