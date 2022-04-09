using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuestGame.Core.Interfaces;
using QuestGame.Items.Interfaces;
using QuestGame.Core.Actions;
using QuestGame.Core.Actions.Abstracts;
using QuestGame.Entities;

namespace QuestGame.Entities.Converters
{
    public class CharacterConverter : JsonConverter<Character>
    {
        private const string nameKey = "name";
        private const string inventoryKey = "inventory";
        private const string dialogsKey = "dialogs";

        public override Character Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = "";
            List<ISlotItem> inventory = null;
            List<IAction> dialogs = null;

            while (reader.Read())
            {
                Console.WriteLine($"(character) {reader.TokenType}");
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        var propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case nameKey:
                                name = reader.GetString();
                                break;
                            case inventoryKey:
                                inventory = JsonSerializer.Deserialize<List<ISlotItem>>(ref reader, options);
                                break;
                            case dialogsKey:
                                dialogs = JsonSerializer.Deserialize<List<IAction>>(ref reader, options);
                                break;
                        }
                        break;
                }
            }

            return new Character(name, dialogs, inventory);
        }

        public override void Write(Utf8JsonWriter writer, Character value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
