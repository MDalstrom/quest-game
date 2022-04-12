using QuestGame.Entities.Models;
using System.Linq;

namespace QuestGame.Actions
{
    public class ShowInventoryAction : ShowTextAction
    {
        private const string phrase = "У вас в инвентаре:\r\n{0}Введите текст, чтобы закрыть меню";

        public ShowInventoryAction(Inventory inventory) : base(null) => message = string.Format(phrase, FormatInventory(inventory));

        public string FormatInventory(Inventory inventory)
        {
            if (inventory.Items.Count == 0) return "---\r\n";

            var result = "";
            for (int i = 0; i < inventory.Items.Count; i++)
            {
                result += $"{i + 1}. {inventory.Items[i].Title}, кол-во: {inventory.Items[i].Count}\r\n";
            }
            return result;
        }
    }
}
