using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuestGame.Entities.Models;
using QuestGame.Actions.Interfaces;
using QuestGame.Actions;

namespace QuestGame.Entities.Converters
{
    [JsonConverter(typeof(Dialog))]
    public class DialogConverter : JsonConverter<Dialog>
    {
        private const string titleKey = "title";
        private const string actionsKey = "actions";
        private const string typeKey = "type";
        private const string roomNameKey = "roomName";
        private const string characterNameKey = "characterName";
        private const string characterFromKey = "characterFrom";
        private const string characterToKey = "characterTo";
        private const string dialogNameKey = "dialogName";
        private const string dialogKey = "dialog";
        private const string itemsKey = "items";

        public override Dialog Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = new Dialog();
            var endDepth = reader.CurrentDepth;
            while (reader.Read())
            {
                if (reader.CurrentDepth == endDepth && reader.TokenType == JsonTokenType.EndObject) return result;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case titleKey:
                            result.Title = reader.GetString();
                            break;
                        case actionsKey:
                            result.Actions = ReadActions(ref reader, options);
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Dialog value, JsonSerializerOptions options)
        {
            writer.WriteString(titleKey, value.Title);
            writer.WriteString(actionsKey, JsonSerializer.Serialize(value.Actions));
        }

        private List<IAction> ReadActions(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var result = new List<IAction>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray) return result;

                switch (reader.TokenType)
                {
                    case JsonTokenType.String:
                        result.Add(new ShowTextAction(reader.GetString()));
                        break;
                    case JsonTokenType.StartArray:
                        result.Add(new ShowSelectionMenuAction(JsonSerializer.Deserialize<List<Dialog>>(ref reader, options)));
                        break;
                    case JsonTokenType.StartObject:
                        result.Add(ReadComplexAction(ref reader, options));
                        break;
                }
            }
            throw new JsonException();
        }

        private IAction ReadComplexAction(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName || reader.GetString() != typeKey) throw new JsonException("Action with no type");

            reader.Read();
            if (!Enum.TryParse<ActionType>(reader.GetString(), true, out var type)) throw new JsonException("Action with no type");

            switch (type)
            {
                case ActionType.AddDialog:
                    return ReadAddDialogAction(ref reader, options);
                case ActionType.RemoveDialog: 
                    return ReadRemoveDialogAction(ref reader, options);
                case ActionType.EndGame:
                    return new EndGameAction();
                case ActionType.Transfer:
                    return ReadTransferItemsAction(ref reader, options);
                default:
                    throw new JsonException("Action of invalid type");
            }
        }

        private AddDialogAction ReadAddDialogAction(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string roomName = "";
            string characterName = "";
            Dialog dialog = new Dialog();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return new AddDialogAction(roomName, characterName, dialog);

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case roomNameKey:
                            roomName = reader.GetString();
                            break;
                        case characterNameKey:
                            characterName = reader.GetString();
                            break;
                        case dialogKey:
                            dialog = JsonSerializer.Deserialize<Dialog>(ref reader, options);
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        private RemoveDialogAction ReadRemoveDialogAction(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string roomName = "";
            string characterName = "";
            string dialogName = "";
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return new RemoveDialogAction(roomName, characterName, dialogName);

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case roomNameKey:
                            roomName = reader.GetString();
                            break;
                        case characterNameKey:
                            characterName = reader.GetString();
                            break;
                        case dialogNameKey:
                            dialogName = reader.GetString();
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        private TransferItemsAction ReadTransferItemsAction(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string roomName = "";
            string characterFrom = "";
            string characterTo = "";
            List<Item> items = null;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return new TransferItemsAction(roomName, characterFrom, characterTo, items);

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case roomNameKey:
                            roomName = reader.GetString();
                            break;
                        case characterFromKey:
                            characterFrom = reader.GetString();
                            break;
                        case characterToKey:
                            characterTo = reader.GetString();
                            break;
                        case itemsKey:
                            items = JsonSerializer.Deserialize<List<Item>>(ref reader, options);
                            break;
                    }
                }
            }
            throw new JsonException();
        }
    }
}
