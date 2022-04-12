using QuestGame.Actions.Abstracts;
using QuestGame.Entities.Models;
using QuestGame.Actions.Utils;
using QuestGame.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestGame.Actions
{
    public class ShowSelectionMenuAction : BaseAction
    {
        protected readonly Dictionary<string, Dialog> dialogs;

        public ShowSelectionMenuAction(Dictionary<string, Dialog> dialogs) => this.dialogs = dialogs;
        public ShowSelectionMenuAction(List<Dialog> dialogs)
        {
            this.dialogs = new Dictionary<string, Dialog>();
            for (int i = 0; i < dialogs.Count; i++)
            {
                this.dialogs.Add(GetKey(i), dialogs[i]);
            }
        }

        public override void Do(IPlayer player)
        {
            Dialog result = null;
            Console.WriteLine(GetMessage());
            while (!dialogs.TryGetValue(Console.ReadLine(), out result))
            {
                Console.WriteLine(GetErrorMessage());
            }
            Console.Clear();
            result.Actions.DoAll(player);
        }

        protected virtual string GetErrorMessage() => "Ответ не распознан, попробуйте ещё раз";
        protected virtual string GetMessage() => string.Join(",\r\n", dialogs.Select(x => $"{x.Key}. {x.Value.Title}"));
        protected virtual string GetKey(int index) => (index + 1).ToString();
    }
}
