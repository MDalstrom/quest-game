using QuestGame.Core.Interfaces;
using QuestGame.Core.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace QuestGame.Entities
{
    [JsonConverter(typeof(RoomConverter))]
    public class Room
    {
        private const string showDescriptionPhrase = "Осмотреть комнату";

        public string Title { get; }
        public string Description { get; }
        public List<Character> Characters { get; }

        public Room(string title, string description, List<Character> characters)
        {
            Title = title;
            Description = description;
            Characters = characters;
        }

        public IAction GetMenu()
        {
            var actions = new List<IAction>();

            var characterDialogs = Characters?.SelectMany(x => x.Dialogs).ToList();
            characterDialogs?.ForEach(x => actions.Add(x));

            actions.Add(new DisplayMessageAction(showDescriptionPhrase, Description));

            return new OpenDialogAction(Title, actions.ToList());
        }
    }
}
