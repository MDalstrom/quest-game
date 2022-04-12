using System.Collections.Generic;
using System.Linq;
using QuestGame.Items.Interfaces;
using QuestGame.Entities.Converters;
using System;
using System.Text.Json.Serialization;

namespace QuestGame.Entities.Models
{
    [JsonConverter(typeof(CharacterConverter))]
    public class Character
    {
        public string Name { get; set;  }
        public List<Dialog> Dialogs { get; set; }
        public Inventory Inventory { get; set; }
    }
}
