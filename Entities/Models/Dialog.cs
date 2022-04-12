using System.Collections.Generic;
using QuestGame.Actions.Interfaces;
using QuestGame.Entities.Converters;
using System.Text.Json.Serialization;

namespace QuestGame.Entities.Models
{
    [JsonConverter(typeof(DialogConverter))]
    public class Dialog
    {
        public string Title { get; set; }
        public List<IAction> Actions { get; set; }
    }
}
