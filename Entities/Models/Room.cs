using System.Collections.Generic;
using System.Text.Json.Serialization;
using QuestGame.Entities.Converters;

namespace QuestGame.Entities.Models
{
    [JsonConverter(typeof(RoomConverter))]
    public class Room
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Character> Characters { get; set; }
    }
}
