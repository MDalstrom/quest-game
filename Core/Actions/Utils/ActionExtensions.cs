using System.Collections.Generic;
using QuestGame.Core.Interfaces;

namespace QuestGame.Core.Actions.Utils
{
    public static class ActionExtensions
    {
        public static string ToMessage(this List<IAction> actions, string starting, string lineTemplate)
        {
            var result = starting;
            for (int i = 0; i < actions.Count; i++)
            {
                result += string.Format(lineTemplate, i, actions[i].Title);
            }
            return result;
        }
    }
}
