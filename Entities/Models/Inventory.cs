using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Entities.Models
{
    public class Inventory
    {
        private readonly List<Item> items;

        public IReadOnlyList<Item> Items => items;

        public Inventory() => items = new List<Item>();
        public Inventory(List<Item> items) => this.items = items;

        public void AddItem(Item toAdd)
        {
            if (items.FirstOrDefault(x => x.Title == toAdd.Title) is var item && item != null)
            {
                item.Count += toAdd.Count;
            }
            else
            {
                items.Add(toAdd);
            }

        }

        public bool TryRemoveItem(Item toRemove)
        {
            if (items.FirstOrDefault(x => x.Title == toRemove.Title) is var item && item.Count > toRemove.Count)
            {
                item.Count -= toRemove.Count;
                if (item.Count == 0) items.Remove(item);
                return true;
            }
            return false;
        }

        public void RemoveAllItems()
        {
            items.Clear();
        }

        public void TransferAllTo(Inventory anotherInventory)
        {
            items.ForEach(x => anotherInventory.AddItem(x));
            RemoveAllItems();
        }

        public bool TryTransferTo(Inventory anotherInventory, string title)
        {
            var item = items.FirstOrDefault(x => x.Title == title);
            if (item == null) return false;

            return TryTransferTo(anotherInventory, item);
        }

        public bool TryTransferTo(Inventory anotherInventory, Item item)
        {
            if (TryRemoveItem(item))
            {
                anotherInventory.AddItem(item);
                return true;
            }
            return false;
        }
    }
}
