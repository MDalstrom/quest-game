using Newtonsoft.Json;
using QuestGame.Entities.Converters;
using QuestGame.Core.Actions.Utils;

namespace QuestGame.Core.Interfaces
{
    [JsonInterfaceConverter(typeof(ActionConverter))]
    public interface IAction
    {
        string Title { get; }
        IAction Do(string arg, out IPlayable result);
    }
}
