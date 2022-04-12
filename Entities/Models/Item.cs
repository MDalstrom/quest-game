using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuestGame.Entities.Models
{
    public class Item
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("count")] public int Count { get; set; }
    }
}
