using QuestGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace QuestGame.Entities.Converters
{
    [JsonConverter(typeof(Room))]
    public class RoomConverter : JsonConverter<Room>
    {
        private const string titleKey = "title";
        private const string descriptionKey = "description";
        private const string charactersKey = "characters";

        public override Room Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = new Room();
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
                        case titleKey:
                            result.Title = reader.GetString();
                            break;
                        case descriptionKey:
                            result.Description = reader.GetString();
                            break;
                        case charactersKey:
                            result.Characters = JsonSerializer.Deserialize<List<Character>>(ref reader, options);
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Room value, JsonSerializerOptions options)
        {
            writer.WriteString(titleKey, value.Title);
            writer.WriteString(descriptionKey, value.Description);
            writer.WriteString(charactersKey, JsonSerializer.Serialize(value.Characters));
        }
    }
}
