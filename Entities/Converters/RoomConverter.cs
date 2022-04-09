using QuestGame.Core.Interfaces;
using QuestGame.Core.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace QuestGame.Entities
{
    public class RoomConverter : JsonConverter<Room>
    {
        private const string titleKey = "title";
        private const string descriptionKey = "description";
        private const string charactersKey = "characters";

        public override Room Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var title = "";
            var description = "";
            List<Character> characters = null;

            while (reader.Read())
            {
                Console.WriteLine(reader.TokenType);
            }

            while (reader.Read())
            {
                Console.WriteLine($"(room) {reader.TokenType}");
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        var propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case titleKey:
                                title = reader.GetString();
                                break;
                            case descriptionKey:
                                description = reader.GetString();
                                break; 
                            case charactersKey:
                                characters = JsonSerializer.Deserialize<List<Character>>(ref reader, options);
                                break;
                        }
                        break;
                }
            }

            return new Room(title, description, characters);
        }

        public override void Write(Utf8JsonWriter writer, Room value, JsonSerializerOptions options)
        {

        }
    }
}
