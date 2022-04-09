using System.Collections.Generic;

namespace QuestGame.Items.Interfaces
{
    public interface IInventory
    {
        IReadOnlyList<ISlotItem> Inventory { get; }

        bool TryTakeItem(string title, out ISlotItem item);
        void GiveItem(ISlotItem item);
    }
}
