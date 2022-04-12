using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuestGame.Items.Interfaces;
using QuestGame.Entities.Models;

namespace QuestGame.Entities.Converters
{
    [JsonConverter(typeof(Character))]
    public class CharacterConverter : JsonConverter<Character>
    {
        private const string nameKey = "name";
        private const string inventoryKey = "inventory";
        private const string dialogsKey = "dialogs";

        public override Character Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = new Character();
            var endDepth = reader.CurrentDepth;
            var endToken = reader.TokenType == JsonTokenType.StartArray ? JsonTokenType.EndArray : JsonTokenType.EndObject;
            while (reader.Read())
            {
                if (reader.CurrentDepth == endDepth && reader.TokenType == endToken) return result;
                
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case nameKey:
                            result.Name = reader.GetString();
                            break;
                        case inventoryKey:
                            result.Inventory = new Inventory(JsonSerializer.Deserialize<List<Item>>(ref reader, options));
                            break;
                        case dialogsKey:
                            result.Dialogs = JsonSerializer.Deserialize<List<Dialog>>(ref reader, options);
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Character value, JsonSerializerOptions options)
        {
            writer.WriteString(nameKey, value.Name);
            writer.WriteString(dialogsKey, JsonSerializer.Serialize(value.Dialogs));
        }
    }
}
