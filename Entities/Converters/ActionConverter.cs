using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuestGame.Core.Interfaces;
using QuestGame.Core.Actions;
using QuestGame.Core.Actions.Abstracts;

namespace QuestGame.Entities.Converters
{
    public class ActionConverter : JsonConverter<IAction>
    {
        private const string titleKey = "title";
        private const string actionsKey = "actions";
        private const string selectionsKey = "selections";

        public override IAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var title = "";
            var isDialog = false;
            var actions = new List<IAction>();

            while (reader.Read())
            {
                Console.WriteLine($"(action) {reader.TokenType}");
                switch (reader.TokenType)
                {
                    case JsonTokenType.False:
                        reader.Read();
                        return new FinishGameAction();
                    case JsonTokenType.String:
                        var message = reader.GetString();
                        reader.Read();
                        return new DisplayMessageAction(title, message);
                    case JsonTokenType.PropertyName:
                        var propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case titleKey:
                                title = reader.GetString();
                                break;
                            case actionsKey:
                                isDialog = false;
                                actions = JsonSerializer.Deserialize<ActionsList>(ref reader, options);
                                break;
                            case selectionsKey:
                                actions = JsonSerializer.Deserialize<List<IAction>>(ref reader, options);
                                break;
                        }
                        break;
                }
            }
            return isDialog ? new OpenDialogAction(title, actions) : new ActionsList(title, actions);
        }

        public override void Write(Utf8JsonWriter writer, IAction value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
